using DailyReport.Models;

namespace DailyReport.Services
{
    public static class OutPatientService
    {
        public static List<string> GetShipping()
        {
            List<string> shipping = new List<string>();
            shipping.Add("СМП");
            shipping.Add("С/О");
            //shipping.Add("Поликлиника");
            //shipping.Add("Др. стационар");
            return shipping;
        }

        public static List<string> GetSubmitedFrom()
        {
            List<string> submiedFrom = new List<string>();
            submiedFrom.Add("С/О");
            submiedFrom.Add("СМП");
            submiedFrom.Add("ГП1");
            submiedFrom.Add("ГП2");
            submiedFrom.Add("ГП3");
            submiedFrom.Add("ГП4");
            submiedFrom.Add("ГП5");
            submiedFrom.Add("ГП6");
            submiedFrom.Add("ГП7");
            submiedFrom.Add("ГП8");
            submiedFrom.Add("ГП8");
            submiedFrom.Add("ГП9");
            submiedFrom.Add("ГБ1");
            submiedFrom.Add("ГБ2");
            submiedFrom.Add("ГБ3");
            submiedFrom.Add("ГБ4");
            submiedFrom.Add("ГБ5");
            submiedFrom.Add("ГБ8");
            submiedFrom.Add("ЦОМиД");
            submiedFrom.Add("ККБ4");
            submiedFrom.Add("ПТД");
            submiedFrom.Add("Наркодиспансер");
            //submiedFrom.Add("");
            //submiedFrom.Add("");
            //submiedFrom.Add("");
            return submiedFrom;
        }

        public static List<string> GetSubmitedTo()
        {
            List<string> submiedTo = new List<string>();
            submiedTo.Add("Амбулаторно");
            submiedTo.Add("Отказ");
            submiedTo.Add("ГБ1");
            submiedTo.Add("ГБ2");
            submiedTo.Add("ГБ3");
            submiedTo.Add("ГБ4");
            submiedTo.Add("ГБ5");
            submiedTo.Add("ГБ8");
            submiedTo.Add("ККБ4");
            submiedTo.Add("ПТД");
            submiedTo.Add("Наркодиспансер");
            //submiedFrom.Add("");
            //submiedFrom.Add("");
            //submiedFrom.Add("");
            return submiedTo;
        }

        public static void AddPatient(OutcomingPatient patient, ApplicationContext context)
        {
            context.OutcomingPatients.Add(patient);
            context.SaveChanges();
        }

        public static void DeleteOutPatient(int id, ApplicationContext context)
        {
            OutcomingPatient patient = (from p in context.OutcomingPatients
                                   where (p.Id == id)
                                   select p).FirstOrDefault();
            if (patient != null)
            {
                context.OutcomingPatients.Remove(patient);
                context.SaveChanges();
            }
        }

        public static void UpdateOutPatient(OutcomingPatient patient, ApplicationContext context)
        {
            OutcomingPatient _patient = (from p in context.OutcomingPatients
                            where (p.Id == patient.Id)
                            select  p).FirstOrDefault();
            if (_patient != null)
            {
                _patient.Name = patient.Name;
                _patient.AgeYears = patient.AgeYears;
                _patient.AgeMonth = patient.AgeMonth;
                _patient.Diagnos = patient.Diagnos;
                _patient.SubmitedFrom = patient.SubmitedFrom;
                _patient.SubmitedTo = patient.SubmitedTo;
                _patient.Shipped = patient.Shipped;
                _patient.Gender = patient.Gender;
                context.SaveChanges();
            }
        }
    }
}
