using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace PetLibrary
{
    public class Pet
    {
        public static string FileName = "pets.txt";
        public string ID { get; set; }

        public string Name { get; set; }

        public string Species { get; set; }

        public DateTime CheckInTime { get; set; }

        public bool isCheckedOut { get; set; }


        public Pet(string id, string name, string species, DateTime checkInTime, bool ischeckedout)
        {
            ID = id;
            Name = name;
            Species = species;
            CheckInTime = checkInTime;
            isCheckedOut = ischeckedout;
        }

        public override string ToString()
        {
            return $"{ID} - {Name} ({Species} {CheckInTime} {isCheckedOut})";
        }

        public async Task SaveAsync()
        {
            StorageFile file = await ApplicationData.Current.LocalFolder.CreateFileAsync(
                FileName,
                CreationCollisionOption.OpenIfExists);

            string line = $"{ID},{Name},{Species},{CheckInTime},{isCheckedOut}";
            await FileIO.AppendTextAsync(file, line + Environment.NewLine);
        }

    }
}
