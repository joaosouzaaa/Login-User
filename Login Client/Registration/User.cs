using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration
{
    class User
    {
        /// <summary>
        /// Constructors
        /// </summary>
        /// <param name="name">Define the name</param>
        /// <param name="password">Define the password</param>
        public User(string name, string password)
        {
            this.Name = name;
            this.Password = password;
        }

        public User() { }
        // Constructor with nothing inside to other classes refer to it when it's not refering to the ones of above.

        public string Name;
        public string Password;
        public void SetName(string name) { this.Name = name; }
        public void SetTelephone(string password) { this.Password = password; }
        //It's defying the constructors from the interface as being the ones from here.

        public virtual void Record()
        {
            var data = this.Read();
            // Verify if the archive exists and tell where to add the constructors in the archive.
            data.Add(this);
            StreamWriter writer = new StreamWriter(Local());
            writer.WriteLine("name; password;");
            // Write the prase above in the .txt archive.
            foreach (User i in data)
            {
                var line = (i.Name + ";" + i.Password + ";");
                writer.WriteLine(line);
                // Set the name and password and write it in the archive.
            }
            writer.Close();
            // Stop writing in the archive.
        }

        private string Local()
        {
            return ConfigurationManager.AppSettings["DatabaseRecord"] + this.GetType().Name + ".txt";
            // Set the local where the archive will be created.
        }

        public List<User> Read()
        {
            var list = new List<User>();
            if (File.Exists(Local()))
            {
                using (StreamReader archive = File.OpenText(Local()))
                // Creates a list from the interface and if the local exists it will create a .txt archive in this local.
                {
                    string line;
                    int i = 0;
                    while ((line = archive.ReadLine()) != null)
                    // While my file be diferent from null it will do:
                    {
                        i++;
                        if (i == 1) continue;
                        var data = line.Split(';');

                        User User1 = new User { Name = data[0], Password = data[1] };
                        list.Add(User1);
                        // It will define the name and password on positions 0, 1 and 2 and add them to the list.
                    }
                }
            }

            return list;
        }
    }
}
