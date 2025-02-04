using System;
using System.Collections.Generic;
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

		//TODO: удалить 
		private static readonly string ShopId = "1237873535";

		public MainWindow()
		{
			InitializeComponent();
			//LoadShops();
			LoadReportTypes();
			LoadStatusComboBox();
		}

		private async void LoadShops()
		{
			//var response = await client.GetAsync($"{BaseUrl}/shops");
			//if (response.IsSuccessStatusCode)
			{
				//	var shopsJson = await response.Content.ReadAsStringAsync();
				//var shops = JsonConvert.DeserializeObject<List<Shop>>(shopsJson);
				//ShopComboBox.ItemsSource = shops;
			}
			//else
			{
				//	MessageBox.Show("Failed to fetch shops.");
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

				if (types.Count() > 0)
				{
					RepairTypeComboBox.SelectedItem = types[0];
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

		private async void LoadRepairTypes()
		{
			var response = await client.GetAsync($"{BaseUrl}/repair-types");
			if (response.IsSuccessStatusCode)
			{
				var repairTypesJson = await response.Content.ReadAsStringAsync();
				var repairTypes = JsonConvert.DeserializeObject<List<RepairType>>(repairTypesJson);
				RepairTypesListBox.ItemsSource = repairTypes;
			}
			else
			{
				MessageBox.Show("Failed to fetch repair types.");
			}
		}

		private void RepairTypesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var selectedRepairType = RepairTypesListBox.SelectedItem as RepairType;
			if (selectedRepairType != null)
			{
				RepairTypeNameTextBox.Text = selectedRepairType.Name;
			}
		}

		private async void AddRepairType_Click(object sender, RoutedEventArgs e)
		{
			var repairTypeData = new
			{
				Name = RepairTypeNameTextBox.Text
			};

			var response = await client.PostAsJsonAsync($"{BaseUrl}/repair-types", repairTypeData);
			if (response.IsSuccessStatusCode)
			{
				MessageBox.Show("Repair type added successfully!");
				LoadRepairTypes(); // Refresh the list
			}
			else
			{
				MessageBox.Show("Failed to add repair type.");
			}
		}

		private async void UpdateRepairType_Click(object sender, RoutedEventArgs e)
		{
			var selectedRepairType = RepairTypesListBox.SelectedItem as RepairType;
			if (selectedRepairType == null)
			{
				MessageBox.Show("Please select a repair type to update.");
				return;
			}

			var repairTypeData = new
			{
				Id = selectedRepairType.Id,
				Name = RepairTypeNameTextBox.Text
			};

			var response = await client.PutAsJsonAsync($"{BaseUrl}/repair-types/{selectedRepairType.Id}", repairTypeData);
			if (response.IsSuccessStatusCode)
			{
				MessageBox.Show("Repair type updated successfully!");
				LoadRepairTypes(); // Refresh the list
			}
			else
			{
				MessageBox.Show("Failed to update repair type.");
			}
		}

		private async void DeleteRepairType_Click(object sender, RoutedEventArgs e)
		{
			var selectedRepairType = RepairTypesListBox.SelectedItem as RepairType;
			if (selectedRepairType == null)
			{
				MessageBox.Show("Please select a repair type to delete.");
				return;
			}

			var response = await client.DeleteAsync($"{BaseUrl}/repair-types/{selectedRepairType.Id}");
			if (response.IsSuccessStatusCode)
			{
				MessageBox.Show("Repair type deleted successfully!");
				LoadRepairTypes(); // Refresh the list
			}
			else
			{
				MessageBox.Show("Failed to delete repair type.");
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
				MessageBox.Show("Client registered successfully!");
			}
			else
			{
				MessageBox.Show("Failed to register client.");
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
			}
			else
			{
				MessageBox.Show("Failed to fetch vehicles.");
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
				MessageBox.Show("Repair entry created successfully!");
			}
			else
			{
				MessageBox.Show("Failed to create repair entry.");
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
			}
			else
			{
				MessageBox.Show("Failed to fetch repairs.");
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
				MessageBox.Show("Repair status updated successfully!");
			}
			else
			{
				MessageBox.Show("Failed to update repair status.");
			}
		}
	}
}