using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using PetLibrary;
using Windows.UI.Popups;
using System.Threading.Tasks;
using Windows.Storage;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PetUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private List<Pet> pets;

        public MainPage()
        {
            this.InitializeComponent();
            LoadPetsOnStartup();  // load and show pets
        }

        string filePath = "pets.txt";

        //private void savePet(Pet pet)
        //{
        //    string line = $"{pet.ID},{pet.Name},{pet.Species},{pet.CheckInTime},{pet.isCheckedOut}";
        //    File.AppendAllText(filePath, line+Environment.NewLine);
        //}

        private async Task SavePetAsync(Pet pet)
        {
            string line = $"{pet.ID},{pet.Name},{pet.Species},{pet.CheckInTime},{pet.isCheckedOut}";

            StorageFile file = await ApplicationData.Current.LocalFolder.CreateFileAsync(
                "pets.txt",
                CreationCollisionOption.OpenIfExists);

            await FileIO.AppendTextAsync(file, line + Environment.NewLine);
        }

        private async void LoadPetsOnStartup()
        {
            pets = await LoadPetsAsync();
            petListView.ItemsSource = pets;
        }


        private async Task<List<Pet>> LoadPetsAsync()
        {
            List<Pet> pets = new List<Pet>();

            try
            {
                StorageFile file = await ApplicationData.Current.LocalFolder.GetFileAsync("pets.txt");
                var lines = await FileIO.ReadLinesAsync(file);

                foreach (var line in lines)
                {
                    var parts = line.Split(',');

                    if (parts.Length >= 5)
                    {
                        Pet pet = new Pet(
                            parts[0],
                            parts[1],
                            parts[2],
                            DateTime.Parse(parts[3]),
                            bool.Parse(parts[4])
                        );

                        pets.Add(pet);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                // File doesn't exist yet — return empty list
            }

            return pets;
        }


        private string GeneratePetId()
        {
            int nextId = pets.Count + 1;
            return $"{nextId.ToString("D8")}";
        }

        private async void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog msg;
            string name = txtPetName.Text;
            string species = txtPetSpecie.Text;

            if(name == "" || species == "")
            {
               msg = new MessageDialog("Please Fill in all details");
                msg.ShowAsync();
                return;
            }

            string id = GeneratePetId();
            Pet newPet = new Pet(id, name, species, DateTime.Now, false);

            // Save directly
            await SavePetAsync(newPet);

            // Reload pets
            pets = await LoadPetsAsync();

           petListView.ItemsSource = null;
           petListView.ItemsSource = pets;

            txtPetName.Text = "";
            txtPetSpecie.Text = "";

            msg = new MessageDialog("Pet added successfully");
            msg.ShowAsync();
            return;
        }
    }
}
