using System;
using DailyReport.Models.WardsModels;

namespace DailyReport.Services.WardServices
{
    public static class PatientServices
    {
        public static Patient CreateTestPatient(int id, bool untoch, bool rash, bool disodered, bool risk)
        {
            BooleanGenerator booleanGenerator = new BooleanGenerator();
            Random random = new Random();
            Patient patient = new();

            patient.Id = id;
            patient.WardNumber = random.Next(1, 4);
            patient.Name = "John Doe";
            patient.Male = booleanGenerator.NextBoolean() ? "М" : "Ж";
            patient.Age = random.Next(1, 80);
            patient.AgeMonts = random.Next(1, 12);
            patient.HospitalisationDate = new DateTime();
            patient.Diagnos = "J06.9";
            patient.HasRash = rash;
            patient.IsUntochable = untoch;
            patient.IsDisodered = disodered;
            patient.HasCareRisk = risk;
            return patient;
        }


        public class BooleanGenerator
        {
            Random rnd;

            public BooleanGenerator()
            {
                rnd = new Random();
            }

            public bool NextBoolean()
            {
                return rnd.Next(0, 2) == 1;
            }
        }
    }
}
