namespace DailyReport.Services
{
    public static class OutPatientService
    {
        public static List<string> Shipping()
        {
            List<string> shipping = new List<string>();
            shipping.Add("СМП");
            shipping.Add("СО");
            shipping.Add("Поликлиника");
            shipping.Add("Др. стационар");
            return shipping;
        }

        public static List<string> SubmitedFrom()
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
            submiedFrom.Add("ККБ4");
            //submiedFrom.Add("");
            //submiedFrom.Add("");
            //submiedFrom.Add("");
            //submiedFrom.Add("");
            //submiedFrom.Add("");
            return submiedFrom;
        }

        public static List<string> SubmitedTo()
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
            //submiedFrom.Add("");
            //submiedFrom.Add("");
            //submiedFrom.Add("");
            //submiedFrom.Add("");
            //submiedFrom.Add("");
            return submiedTo;
        }
    }
}
