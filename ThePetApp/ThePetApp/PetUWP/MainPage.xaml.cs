using System;
using System.Collections.Generic;
using System.IO;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using PetLibrary;
using Windows.UI.Popups;
using Windows.Storage;
using System.Threading.Tasks;

namespace PetUWP
{
    public sealed partial class MainPage : Page
    {
        private List<Pet> pets = new List<Pet>();

        public MainPage()
        {
            this.InitializeComponent();

            // Set shared save path for all Pet instances
            Pet.SavePath =  "pets.txt";

            // Load pets initially
            pets = LoadPets();
            petListView.ItemsSource = pets;
        }

        private string GeneratePetId()
        {
            int nextId = pets.Count + 1;
            return $"{nextId.ToString("D8")}";
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog msg;
            string name = txtPetName.Text;
            string species = txtPetSpecie.Text;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(species))
            {
                msg = new MessageDialog("Please fill in all details");
                _ = msg.ShowAsync();
                return;
            }

            string id = GeneratePetId();
            Pet newPet = new Pet(id, name, species, DateTime.Now, false);

            // Save using method from Pet class
            newPet.Save();

            // Reload and display updated list
            pets = LoadPets();
            petListView.ItemsSource = null;
            petListView.ItemsSource = pets;

            txtPetName.Text = "";
            txtPetSpecie.Text = "";

            msg = new MessageDialog("Pet added successfully");
            _ = msg.ShowAsync();
        }

        private List<Pet> LoadPets()
        {
            List<Pet> loadedPets = new List<Pet>();

            try
            {
                string path = Pet.SavePath;

                if (File.Exists(path))
                {
                    var lines = File.ReadAllLines(path);

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
            }
            catch (Exception ex)
            {
                _ = new MessageDialog("Error loading pets: " + ex.Message).ShowAsync();
            }

            return loadedPets;
        }
    }
}
