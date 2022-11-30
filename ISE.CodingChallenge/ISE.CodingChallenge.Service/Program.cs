using ISE.CodingChallenge.API;
using System.Text.Json;
using System.Collections.Generic;
using System.IO;
using System;
using System.Globalization;
using ISE.CodingChallenge.API.Model;
using CsvHelper;
using System.Text;
using System.Data;
using System.Xml;
using System.Security.Cryptography.X509Certificates;
using ISE.CodingChallenge.Service;
using System.Xml.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        var gService = new GroupService();
        var uService = new UserService();

        var csv = File.ReadAllLines("C:\\Users\\code.interview\\source\\repos\\ISEAG_Probeaufgabe\\ISE.CodingChallenge\\data\\users.csv");
        List<MappedCsv> users = new List<MappedCsv>();
        foreach (string line in csv)
        {
            var delimitedLine = line.Split(','); 

            users.Add(new MappedCsv(delimitedLine[1], delimitedLine[2]));

            foreach (var item in users)
            {
                uService.AddUser(delimitedLine[1] + delimitedLine[2], delimitedLine[1] + "." + delimitedLine[2] + "@hogwarts.com");
            }
        }

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml("C:\\Users\\code.interview\\source\\repos\\ISEAG_Probeaufgabe\\ISE.CodingChallenge\\data\\lessons.xml");

        XmlNodeList lessons = xmlDoc.SelectNodes("/dataset/record/lesson/title");
        foreach (XmlNode xn in lessons)
        {
            Console.WriteLine(xn.InnerText);
        }








    }
}