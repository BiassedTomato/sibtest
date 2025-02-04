using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;

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
			StatusComboBox.ItemsSource = new List<string> { "Pending", "InProgress", "Completed", "Cancelled" };
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
				RepairType = Guid.Parse(RepairTypeComboBox.SelectedItem.ToString()),
			};

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
				RepairEntryId = (RepairStatusComboBox.SelectedItem as Repair)?.RepairType,
				NewStatus = StatusComboBox.SelectedItem.ToString()
			};

			var response = await client.PutAsJsonAsync($"{BaseUrl}/url4", statusData);
			if (response.IsSuccessStatusCode)
			{
				MessageBox.Show("Repair status updated successfully!");
			}
			else
			{
				MessageBox.Show("Failed to update repair status.");
			}
		}

		private async void FetchRepairsForFinish_Click(object sender, RoutedEventArgs e)
		{
			var clientId = FinishClientIdTextBox.Text;
			var response = await client.GetAsync($"{BaseUrl}/repairs?clientId={clientId}");
			if (response.IsSuccessStatusCode)
			{
				var repairsJson = await response.Content.ReadAsStringAsync();
				var repairs = JsonConvert.DeserializeObject<List<Repair>>(repairsJson);
				RepairFinishComboBox.ItemsSource = repairs;
			}
			else
			{
				MessageBox.Show("Failed to fetch repairs.");
			}
		}

		private async void FinishRepair_Click(object sender, RoutedEventArgs e)
		{
			var repairId = (RepairFinishComboBox.SelectedItem as Repair)?.RepairType;
			var response = await client.PostAsJsonAsync($"{BaseUrl}/url5", new { RepairEntryId = repairId });
			if (response.IsSuccessStatusCode)
			{
				MessageBox.Show("Repair finished successfully!");
			}
			else
			{
				MessageBox.Show("Failed to finish repair.");
			}
		}
	}

	public class Shop
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}

	public class Vehicle
	{
		public string ClientNumber { get; set; }
		public string Model { get; set; }
		public string VehicleNumber { get; set; }
	}

	public class Repair
	{
		public string ClientNumber { get; set; }
		public float Cost { get; set; }
		public string VehicleNumber { get; set; }
		public float Mileage { get; set; }
		public Guid RepairType { get; set; }
	}

	public class RepairType
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public float Cost { get; set; }
	}
}