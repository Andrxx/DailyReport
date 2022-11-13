using DailyReport.Models;

namespace DailyReport.Services
{
    public static class DutyServices
    {


        public static List<string> GetDoctorsList()
        {
            List<string> doctors = new List<string>();
            doctors.Add("Вакулина Татьяна Сергеевна");
            doctors.Add("Ковалев Андрей Николаевич");
            doctors.Add("Мурашова Елена ");
            doctors.Add("Чумакова Юлия");
            doctors.Add("Британова Анастасия ");
            doctors.Add("Британов Виталий Сергеевич");
            doctors.Add("Демченко Ростислав");
            doctors.Add("Варнавская Анна Александровна");
            doctors.Add("Матушкина Валерия ");
            doctors.Add("Нурбалина Айлана Маратовна");
            doctors.Add("Водянина Дарья ");
            doctors.Add("Овчаров Юрий Владимирович");
            doctors.Add("Голенковская Юлия ");
            doctors.Add("Моисеева Полина Алексеевна");
            doctors.Add("Козлова Юлия Игоревна");
            doctors.Add("Кравцов ");
            //doctors.Add("");
            //doctors.Add("");
            //doctors.Add("");
            //doctors.Add("");
            //doctors.Add("");
            return doctors;
        }

        public static List<DutyDoc> GetDutyShifts()
        {
            List<DutyDoc> dutyShifts = new();

            return dutyShifts;
        }

        public static void AddDutyDoc(DutyDoc dutyShift)
        {
            
        }
        public static void DeleteDutyDoc(DutyDoc dutyShift)
        {

        }

    }
}
