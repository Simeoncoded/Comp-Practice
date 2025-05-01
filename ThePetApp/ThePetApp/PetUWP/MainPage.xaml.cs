using System;
using System.Collections.Generic;
using System.IO;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using PetLibrary;
using Windows.UI.Popups;
using Windows.Storage;
using System.Threading.Tasks;
using System.Linq;

namespace PetUWP
{
    public sealed partial class MainPage : Page
    {
        private List<Pet> pets = new List<Pet>();

        public MainPage()
        {
            this.InitializeComponent();
            _ = LoadAndBindPetsAsync();
        }

        private async Task LoadAndBindPetsAsync()
        {
            pets = await LoadPetsAsync();
            petListView.ItemsSource = pets;
        }

        private string GeneratePetId()
        {
            if (pets.Count == 0)
            {
                return "00000001";
            }
            else
            {
                int maxId = 0;

                foreach (var pet in pets)
                {
                    int number;
                    if (int.TryParse(pet.ID, out number))
                    {
                        if (number > maxId)
                        {
                            maxId = number;
                        }
                    }
                }

                int nextId = maxId + 1;
                return nextId.ToString("D8");
            }
        }


        private async void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog msg;
            string name = txtPetName.Text;
            string species = txtPetSpecie.Text;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(species))
            {
                msg = new MessageDialog("Please fill in all details");
                await msg.ShowAsync();
                return;
            }

            string id = GeneratePetId();
            Pet newPet = new Pet(id, name, species, DateTime.Now, false);

            await newPet.SaveAsync();  // Uses ApplicationData.Current.LocalFolder

            pets = await LoadPetsAsync();
            petListView.ItemsSource = null;
            petListView.ItemsSource = pets;

            txtPetName.Text = "";
            txtPetSpecie.Text = "";

            msg = new MessageDialog("Pet added successfully");
            await msg.ShowAsync();
        }

        private async Task<List<Pet>> LoadPetsAsync()
        {
            List<Pet> loadedPets = new List<Pet>();

            try
            {
                StorageFile file = await ApplicationData.Current.LocalFolder.CreateFileAsync(
                    Pet.FileName,
                    CreationCollisionOption.OpenIfExists);

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

                        loadedPets.Add(pet);
                    }
                }
            }
            catch (Exception ex)
            {
                await new MessageDialog("Error loading pets: " + ex.Message).ShowAsync();
            }

            return loadedPets;
        }

        private async void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            string idToRemove = txtRemid.Text.Trim();

            if (string.IsNullOrWhiteSpace(idToRemove))
            {
                await new MessageDialog("Please enter a valid Pet ID.").ShowAsync();
                return;
            }

            var petToRemove = pets.FirstOrDefault(p => p.ID == idToRemove);

            if (petToRemove == null)
            {
                await new MessageDialog("Pet not found.").ShowAsync();
                return;
            }

            pets.Remove(petToRemove);

            // Write updated list to file
            StorageFile file = await ApplicationData.Current.LocalFolder.CreateFileAsync(
                Pet.FileName,
                CreationCollisionOption.ReplaceExisting);

            await FileIO.WriteLinesAsync(file, pets.Select(p =>
                $"{p.ID},{p.Name},{p.Species},{p.CheckInTime},{p.isCheckedOut}"));

            petListView.ItemsSource = null;
            petListView.ItemsSource = pets;

            txtRemid.Text = "";
            await new MessageDialog("Pet removed successfully.").ShowAsync();
        }

        private async void btnCheckout_Click(object sender, RoutedEventArgs e)
        {
            string idToCheckout = txtRemid.Text.Trim();

            if (string.IsNullOrWhiteSpace(idToCheckout))
            {
                MessageDialog mgg = new MessageDialog("Please enter a valid Pet ID.");
                mgg.ShowAsync();
                return;
            }

            var petToCheckout = pets.FirstOrDefault(p => p.ID == idToCheckout);

            if (petToCheckout == null)
            {
                MessageDialog mgg = new MessageDialog("Pet not found.");
                mgg.ShowAsync();
                return;
            }

            // Mark the pet as checked out
            petToCheckout.isCheckedOut = true;

            // Write updated list to file
            StorageFile file = await ApplicationData.Current.LocalFolder.CreateFileAsync(
                Pet.FileName,
                CreationCollisionOption.ReplaceExisting);

            await FileIO.WriteLinesAsync(file, pets.Select(p =>
                $"{p.ID},{p.Name},{p.Species},{p.CheckInTime},{p.isCheckedOut}"));

            petListView.ItemsSource = null;
            petListView.ItemsSource = pets;

            txtRemid.Text = "";
            await new MessageDialog("Pet checkedout successfully.").ShowAsync();
        }
    }
}
