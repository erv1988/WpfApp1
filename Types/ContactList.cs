using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WpfApp1
{
    public abstract class ContactList
    {
        /// <summary>
        /// Метод загрузки данных из файла
        /// </summary>
        /// <param name="filePath"></param>
        public abstract void LoadFromFile(string filePath);

        /// <summary>
        /// Метод сохранения данных в файл
        /// </summary>
        /// <param name="filePath"></param>
        public abstract void Save();


        /// <summary>
        /// Метод получения списка контактов
        /// </summary>
        /// <returns></returns>
        public abstract ObservableCollection<Contact> GetContactList();

        public ObservableCollection<Contact> Contacts { get; set; }
    }

    public class ContactListFromXml : ContactList
    {
        public const string ContactListFile = "contactlist.xml";
        private string _filePath = null;

        public override ObservableCollection<Contact> GetContactList()
        {
            return Contacts;
        }

        public override void LoadFromFile(string filePath)
        {
            // Создание автоматического сериализатора
            XmlSerializer xs = new XmlSerializer(typeof(List<Contact>));
            _filePath = filePath;
            // Проверка на наличие файла
            if (File.Exists(filePath))
            {
                using (var stream = File.OpenRead(filePath))      // открытие файла
                using (var sr = new StreamReader(stream, Encoding.UTF8)) // кодировка - UTF8
                {
                    try
                    {
                        Contacts = new ObservableCollection<Contact>();
                        IList<Contact> list = xs.Deserialize(sr) as IList<Contact>;
                        foreach (var i in list)
                            Contacts.Add(i); 
                    }
                    catch
                    {
                        Contacts = new ObservableCollection<Contact>();
                    }
                }
            }
            else
            {
                Contacts = new ObservableCollection<Contact>();
            }
        }

        public override void Save()
        {
            // Создание автоматического сериализатора
            XmlSerializer xs = new XmlSerializer(typeof(List<Contact>));
            // Проверка на наличие файла
            using (var stream = File.Create(_filePath))      // открытие файла
            using (var sr = new StreamWriter(stream, Encoding.UTF8)) // кодировка - UTF8
            {
                try
                {
                    xs.Serialize(sr, Contacts);
                }
                catch
                {
                }
            }
        }
    }
}
