using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SmartHouseDll
{
    [Serializable]
    public class SerDesHouse
    {
        private static string pathFile = @"D:\11.dat";

        static public void Save(House house)
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            try
            {
                using (Stream fStream = new FileStream(pathFile, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    binFormat.Serialize(fStream, house);
                }
            }
            catch (Exception e)
            {

            }
        }
        static public House Read()
        {
            if (File.Exists(pathFile))
            {
                BinaryFormatter binFormat = new BinaryFormatter();
                using (Stream fStream = File.OpenRead(pathFile))
                {
                    return binFormat.Deserialize(fStream) as House;
                }
            }
            return Initialization();
        }

        private static House Initialization()
        {
            House house = new House("Дом1");
            house.AddRoom(new Room("Зал"));
            house.AddRoom(new Room("Кухня"));

            house.AddDevice("Зал", new ClimatControl("Климат"));

            HouseCinema cinema = new HouseCinema("Кинотеатр");

            Tv tv = new Tv("TV1");
            tv.Connection(cinema);

            DVDPlayer dvd = new DVDPlayer("DVD");
            dvd.Connection(cinema);


            house.AddDevice("Зал", cinema);
            house.AddDevice("Зал", new DVDPlayer("DVD"));
            house.AddDevice("Зал", new Tv("TV1"));
            house.AddDevice("Зал", new Tv("TV2"));
            house.AddDevice("Зал", new Lamp("Лампа1"));
            house.AddDevice("Зал", new Lamp("Лампа2"));

            house.AddDevice("Кухня", new Tv("TV"));
            house.AddDevice("Кухня", new Heating("Heating"));
            house.AddDevice("Кухня", new Conditioner("Condition"));
            house.AddDevice("Кухня", new Lamp("Лампа1"));
            house.AddDevice("Кухня", new Lamp("Лампа2"));

            return house;

        }
    }
}