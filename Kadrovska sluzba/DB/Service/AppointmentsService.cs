using Dapper;
using Dapper.Contrib.Extensions;
using Kadrovska_sluzba.DB.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kadrovska_sluzba.DB.Service
{
    public class AppointmentsService
    {
        private IDbConnection _db = new SqlConnection(DbConnection.ConnectionString());
        private void Create(Appointments appointment)
        {
            int rowsAffected = _db.Execute(@"INSERT INTO [dbo].[Appointments] ([Type], [StartDate], [EndDate], [AllDay], [Subject], [Location], [Description], [Status], [Label],[ResourceID], [ResourceIDs], [ReminderInfo], [RecurrenceInfo], [TimeZoneId], [CustomField1]) " +
                "VALUES (@Type, @StartDate, @EndDate, @AllDay, @Subject, @Location, @Description, @Status, @Label, @ResourceID, @ResourceIDs, @ReminderInfo, @RecurrenceInfo, @TimeZoneId, @CustomField1) ",
                new
                {
                    Type = appointment.Type,
                    StartDate = appointment.StartDate,
                    EndDate = appointment.EndDate,
                    AllDay = appointment.AllDay,
                    Subject = appointment.Subject,
                    Location = appointment.Location,
                    Description = appointment.Description,
                    Status = appointment.Status,
                    Label = appointment.Label,
                    ResourceID = appointment.ResourceID,
                    ResourceIDs = appointment.ResourceIDs,
                    ReminderInfo = appointment.ReminderInfo,
                    RecurrenceInfo = appointment.RecurrenceInfo,
                    TimeZoneId = appointment.TimeZoneId,
                    CustomField1 = appointment.CustomField1
                });
        }

        public void DodajRodjendan(Radnik radnik)
        {
            RadnikService rs = new RadnikService();
            int label = (int)Settings.KalendarLabele.Rodjendan;
            DeleteIfExist(radnik.ID, label);
            DateTime datum = (DateTime)radnik.DatumRodjenja;
            Appointments rodjendan = new Appointments();
            rodjendan.Type = 1;
            rodjendan.StartDate = SharedService.StartOfDay(datum);
            rodjendan.EndDate = SharedService.EndOfDay(datum);
            rodjendan.AllDay = false;
            rodjendan.Subject = string.Format("Rođendan - {0} {1}", radnik.Prezime, radnik.Ime);
            rodjendan.Location = string.Empty;
            rodjendan.Description = string.Empty;
            rodjendan.Status = 0;
            rodjendan.Label = label;
            rodjendan.ResourceID = null;
            rodjendan.ResourceIDs = null;
            rodjendan.ReminderInfo = null;// string.Format("< Reminders >< Reminder AlertTime = '{0}' /></ Reminders >", datum);
            rodjendan.RecurrenceInfo = string.Format(@"<RecurrenceInfo Start=""{0}/{1}/{2} 00:00:00"" DayNumber=""{1}"" WeekOfMonth=""0"" WeekDays=""0"" Id =""{3}"" Month=""{0}"" Range=""1"" Type=""3"" Version =""1"" />", datum.Month, datum.Day, datum.Year, Guid.NewGuid());
            rodjendan.TimeZoneId = "Central European Standard Time";
            rodjendan.CustomField1 = radnik.ID.ToString();
            Create(rodjendan);
            //return rodjendan;
        }
        public void DodajGodisnjicu10(Radnik radnik)
        {
            RadnikService rs = new RadnikService();
            int label = (int)Settings.KalendarLabele.Godisnjica10;
            DeleteIfExist(radnik.ID, label);
            DateTime datum = (DateTime)radnik.DatumZapos;
            datum = datum.AddYears(10);
            Appointments godisnjica = new Appointments();
            godisnjica.Type = 0;
            godisnjica.StartDate = SharedService.StartOfDay(datum);
            godisnjica.EndDate = SharedService.EndOfDay(datum);
            godisnjica.AllDay = false;
            godisnjica.Subject = string.Format("10. godišnjica zaposlenja - {0} {1}", radnik.Prezime, radnik.Ime);
            godisnjica.Location = string.Empty;
            godisnjica.Description = string.Empty;
            godisnjica.Status = 0;
            godisnjica.Label = label;
            godisnjica.ResourceID = null;
            godisnjica.ResourceIDs = null;
            godisnjica.ReminderInfo = null; // string.Format("< Reminders >< Reminder AlertTime = '{0}' /></ Reminders >", datum);
            godisnjica.RecurrenceInfo = null; // string.Format(@"<RecurrenceInfo Start=""{0}/{1}/{2} 00:00:00"" DayNumber=""{1}"" WeekOfMonth=""0"" WeekDays=""0"" Id =""{3}"" Month=""{0}"" Range=""1"" Type=""3"" Version =""1"" />", datum.Month, datum.Day, datum.Year, Guid.NewGuid());
            godisnjica.TimeZoneId = "Central European Standard Time";
            godisnjica.CustomField1 = radnik.ID.ToString();
            Create(godisnjica);
            //return godisnjica;
        }
        public void DodajGodisnjicu20(Radnik radnik)
        {
            RadnikService rs = new RadnikService();
            int label = (int)Settings.KalendarLabele.Godisnjica20;
            DeleteIfExist(radnik.ID, label);
            DateTime datum = (DateTime)radnik.DatumZapos;
            datum = datum.AddYears(20);
            Appointments godisnjica = new Appointments();
            godisnjica.Type = 0;
            godisnjica.StartDate = SharedService.StartOfDay(datum);
            godisnjica.EndDate = SharedService.EndOfDay(datum);
            godisnjica.AllDay = false;
            godisnjica.Subject = string.Format("20. godišnjica zaposlenja - {0} {1}", radnik.Prezime, radnik.Ime);
            godisnjica.Location = string.Empty;
            godisnjica.Description = string.Empty;
            godisnjica.Status = 0;
            godisnjica.Label = label;
            godisnjica.ResourceID = null;
            godisnjica.ResourceIDs = null;
            godisnjica.ReminderInfo = null;// string.Format("< Reminders >< Reminder AlertTime = '{0}' /></ Reminders >", datum);
            godisnjica.RecurrenceInfo = null;// string.Format(@"<RecurrenceInfo Start=""{0}/{1}/{2} 00:00:00"" DayNumber=""{1}"" WeekOfMonth=""0"" WeekDays=""0"" Id =""{3}"" Month=""{0}"" Range=""1"" Type=""3"" Version =""1"" />", datum.Month, datum.Day, datum.Year, Guid.NewGuid());
            godisnjica.TimeZoneId = "Central European Standard Time";
            godisnjica.CustomField1 = radnik.ID.ToString();
            Create(godisnjica);
            //return godisnjica;
        }
        public void DodajGodisnjicu25(Radnik radnik)
        {
            RadnikService rs = new RadnikService();
            int label = (int)Settings.KalendarLabele.Godisnjica25;
            DeleteIfExist(radnik.ID, label);
            DateTime datum = (DateTime)radnik.DatumZapos;
            datum = datum.AddYears(25);
            Appointments godisnjica = new Appointments();
            godisnjica.Type = 0;
            godisnjica.StartDate = SharedService.StartOfDay(datum);
            godisnjica.EndDate = SharedService.EndOfDay(datum);
            godisnjica.AllDay = false;
            godisnjica.Subject = string.Format("25. godišnjica zaposlenja - {0} {1}", radnik.Prezime, radnik.Ime);
            godisnjica.Location = string.Empty;
            godisnjica.Description = string.Empty;
            godisnjica.Status = 0;
            godisnjica.Label = label;
            godisnjica.ResourceID = null;
            godisnjica.ResourceIDs = null;
            godisnjica.ReminderInfo = null;// string.Format("< Reminders >< Reminder AlertTime = '{0}' /></ Reminders >", datum);
            godisnjica.RecurrenceInfo = null;// string.Format(@"<RecurrenceInfo Start=""{0}/{1}/{2} 00:00:00"" DayNumber=""{1}"" WeekOfMonth=""0"" WeekDays=""0"" Id =""{3}"" Month=""{0}"" Range=""1"" Type=""3"" Version =""1"" />", datum.Month, datum.Day, datum.Year, Guid.NewGuid());
            godisnjica.TimeZoneId = "Central European Standard Time";
            godisnjica.CustomField1 = radnik.ID.ToString();
            Create(godisnjica);
            //return godisnjica;
        }
        public void DodajGodisnjicu30(Radnik radnik)
        {
            RadnikService rs = new RadnikService();
            int label = (int)Settings.KalendarLabele.Godisnjica30;
            DeleteIfExist(radnik.ID, label);
            DateTime datum = (DateTime)radnik.DatumZapos;
            datum = datum.AddYears(30);
            Appointments godisnjica = new Appointments();
            godisnjica.Type = 0;
            godisnjica.StartDate = SharedService.StartOfDay(datum);
            godisnjica.EndDate = SharedService.EndOfDay(datum);
            godisnjica.AllDay = false;
            godisnjica.Subject = string.Format("30. godišnjica zaposlenja - {0} {1}", radnik.Prezime, radnik.Ime);
            godisnjica.Location = string.Empty;
            godisnjica.Description = string.Empty;
            godisnjica.Status = 0;
            godisnjica.Label = label;
            godisnjica.ResourceID = null;
            godisnjica.ResourceIDs = null;
            godisnjica.ReminderInfo = null; // string.Format("< Reminders >< Reminder AlertTime = '{0}' /></ Reminders >", datum);
            godisnjica.RecurrenceInfo = null; // string.Format(@"<RecurrenceInfo Start=""{0}/{1}/{2} 00:00:00"" DayNumber=""{1}"" WeekOfMonth=""0"" WeekDays=""0"" Id =""{3}"" Month=""{0}"" Range=""1"" Type=""3"" Version =""1"" />", datum.Month, datum.Day, datum.Year, Guid.NewGuid());
            godisnjica.TimeZoneId = "Central European Standard Time";
            godisnjica.CustomField1 = radnik.ID.ToString();
            Create(godisnjica);
            //return godisnjica;
        }
        public void DodajIstekUgovora(Radnik radnik)
        {
            DateTime datum;
            try
            {

                datum = (DateTime)radnik.DatumZapos;
                RadnikService rs = new RadnikService();
                int label = (int)Settings.KalendarLabele.IstekUgovora;
                DeleteIfExist(radnik.ID, label);
                Appointments istek = new Appointments();
                istek.Type = 0;
                istek.StartDate = SharedService.StartOfDay((DateTime)radnik.DatumIstekaUgovora);
                istek.EndDate = SharedService.EndOfDay((DateTime)radnik.DatumIstekaUgovora);
                istek.AllDay = false;
                istek.Subject = string.Format("Istek ugovora - {0} {1}", radnik.Prezime, radnik.Ime);
                istek.Location = string.Empty;
                istek.Description = string.Empty;
                istek.Status = 0;
                istek.Label = label;
                istek.ResourceID = null;
                istek.ResourceIDs = null;
                istek.ReminderInfo = null; // string.Format("< Reminders >< Reminder AlertTime = '{0}' /></ Reminders >", datum);
                istek.RecurrenceInfo = null; // string.Format(@"<RecurrenceInfo Start=""{0}/{1}/{2} 00:00:00"" DayNumber=""{1}"" WeekOfMonth=""0"" WeekDays=""0"" Id =""{3}"" Month=""{0}"" Range=""1"" Type=""3"" Version =""1"" />", datum.Month, datum.Day, datum.Year, Guid.NewGuid());
                istek.TimeZoneId = "Central European Standard Time";
                istek.CustomField1 = radnik.ID.ToString();
                Create(istek);
                //return istek;
            }
            catch (Exception)
            {
            }

        }

        private void DeleteIfExist(int radId, int label)
        {
            _db.Execute(string.Format("DELETE FROM [dbo].[Appointments] WHERE CustomField1 = '{0}' and Label = {1}", radId, label));
        }
        public void DeleteAll(Settings.KalendarLabele label)
        {
            _db.Execute(string.Format("DELETE FROM [dbo].[Appointments] WHERE Label = {0} and ISNULL(CustomField1,'')<>''", (int)label));
        }
    }
}
