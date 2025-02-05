using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;
using ShopDesktop.Models;

namespace RepairManagementApp
{
	public partial class MainWindow : Window
	{
		private static readonly HttpClient client = new HttpClient();
		private const string BaseUrl = "https://localhost:5001/shop";

		private static string? ShopId { get; set; }

		public MainWindow()
		{
			ShopId = ConfigurationManager.AppSettings["shopId"];
			InitializeComponent();
			try
			{
				LoadReportTypes();
				LoadStatusComboBox();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Не удалось получить данные. Проверьте подключение и перезапустите программу.");
			}
		}

		public async void LoadReportTypes()
		{
			var response = await client.GetAsync($"{BaseUrl}/getRepairTypes");
			if (response.IsSuccessStatusCode)
			{
				var typesJson = await response.Content.ReadAsStringAsync();
				var types = JsonConvert.DeserializeObject<List<RepairType>>(typesJson).Select(x => new RepairType()
				{
					Cost = x.Cost,
					Name = $"{x.Name} ({x.Cost} руб.)",
					Id = x.Id
				}).ToList();

				if (types.Count > 0)
				{
					RepairTypeComboBox.SelectedIndex = 0;
				}

				RepairTypeComboBox.ItemsSource = types;
			}
			else
			{
				MessageBox.Show("Не удалось получить типы услуг.");
			}
		}

		private void LoadStatusComboBox()
		{
			StatusComboBox.ItemsSource = Enum.GetValues<RepairStatus>().Select(x => new { Name = x.ToString(), Id = (int)x });
			StatusComboBox.SelectedIndex = 0;
		}

		private async void AssignVehicle_Click(object sender, RoutedEventArgs e)
		{
			var vehicleData = new
			{
				ClientNumber = AssignClientIdTextBox.Text,
				Model = VehicleModelTextBox.Text,
				VehicleNumber = VehicleNumberTextBox.Text
			};

			if (string.IsNullOrEmpty(vehicleData.ClientNumber) || string.IsNullOrEmpty(vehicleData.Model) || string.IsNullOrEmpty(vehicleData.VehicleNumber))
			{
				MessageBox.Show("Все поля должны быть заполнены.");
				return;
			}

			var response = await client.PostAsJsonAsync($"{BaseUrl}/addVehicle", vehicleData);
			if (response.IsSuccessStatusCode)
			{
				MessageBox.Show("Транспортное средство успешно создано!");
			}
			else
			{
				MessageBox.Show("Не удалось создать транспортное средство.");
			}
		}


	private async void RegisterClient_Click(object sender, RoutedEventArgs e)
		{
			var clientData = new
			{
				FirstName = FirstNameTextBox.Text,
				LastName = LastNameTextBox.Text,
				ClientNumber = IdNumberTextBox.Text,
				ShopNumber = ShopId
			};

			if (string.IsNullOrEmpty(clientData.FirstName) || string.IsNullOrEmpty(clientData.LastName) || string.IsNullOrEmpty(clientData.ClientNumber))
			{
				MessageBox.Show("Все поля должны быть заполнены.");
				return;
			}

			var response = await client.PostAsJsonAsync($"{BaseUrl}/registerClient", clientData);
			if (response.IsSuccessStatusCode)
			{
				MessageBox.Show("Регистрация клиента успешна!");
			}
			else
			{
				MessageBox.Show("Ошибка регистрации клиента.");
			}
		}

		private async void FetchVehicles_Click(object sender, RoutedEventArgs e)
		{
			var clientId = RepairClientIdTextBox.Text;
			var response = await client.GetAsync($"{BaseUrl}/vehicles?clientId={clientId}");
			if (response.IsSuccessStatusCode)
			{
				var vehiclesJson = await response.Content.ReadAsStringAsync();
				var vehicles = JsonConvert.DeserializeObject<List<Vehicle>>(vehiclesJson);
				VehicleComboBox.ItemsSource = vehicles;

				if (vehicles != null && vehicles.Count > 0)
				{
					VehicleComboBox.SelectedIndex = 0;
				}
			}
			else
			{
				MessageBox.Show("Не удалось получить список ТС.");
			}
		}

		private async void CreateRepairEntry_Click(object sender, RoutedEventArgs e)
		{
			var repairData = new
			{
				VehicleNumber = (VehicleComboBox.SelectedItem as Vehicle)?.VehicleNumber,
				ClientNumber = RepairClientIdTextBox.Text,
				RepairType = (RepairTypeComboBox.SelectedItem as RepairType)?.Id,
			};

			if (repairData.VehicleNumber == null || string.IsNullOrEmpty(repairData.ClientNumber) || repairData.RepairType == null)
			{
				MessageBox.Show("Все поля должны быть заполнены.");

				return;
			}

			var response = await client.PostAsJsonAsync($"{BaseUrl}/createRepair", repairData);
			if (response.IsSuccessStatusCode)
			{
				MessageBox.Show("Услуга была начата.");
			}
			else
			{
				MessageBox.Show("Не удалось начать услугу.");
			}
		}

		private async void FetchRepairsForStatus_Click(object sender, RoutedEventArgs e)
		{
			var clientId = StatusClientIdTextBox.Text;
			var response = await client.GetAsync($"{BaseUrl}/repairs?clientId={clientId}");
			if (response.IsSuccessStatusCode)
			{
				var repairsJson = await response.Content.ReadAsStringAsync();
				var repairs = JsonConvert.DeserializeObject<List<Repair>>(repairsJson);
				RepairStatusComboBox.ItemsSource = repairs;

				if(repairs!=null&&repairs.Count>0)
				{
					RepairStatusComboBox.SelectedIndex = 0;
				}
			}
			else
			{
				MessageBox.Show("Не удалось получить список активных услуг.");
			}
		}

		private async void ChangeRepairStatus_Click(object sender, RoutedEventArgs e)
		{
			var statusData = new
			{
				RepairEntryId = (RepairStatusComboBox.SelectedItem as Repair)?.Id,
				NewStatus = StatusComboBox.SelectedValue
			};

			if (statusData.NewStatus == null || statusData.RepairEntryId == null)
			{
				MessageBox.Show("Все поля должны быть заполнены.");

				return;
			}

			var response = await client.PatchAsync($"{BaseUrl}/changeRepairStatus?repairId={RepairStatusComboBox.SelectedValue}&status={(int)StatusComboBox.SelectedValue}", null);
			if (response.IsSuccessStatusCode)
			{
				MessageBox.Show("Статус услуги успешно обновлен!");
			}
			else
			{
				MessageBox.Show("Ошибка обновления статуса услуги.");
			}
		}
	}
}