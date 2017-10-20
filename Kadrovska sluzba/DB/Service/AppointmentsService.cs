using Dapper;
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
        public void Create(Appointments appointment)
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
                    Label=appointment.Label,
                    ResourceID=appointment.ResourceID,
                    ResourceIDs=appointment.ResourceIDs,
                    ReminderInfo=appointment.ReminderInfo,
                    RecurrenceInfo=appointment.RecurrenceInfo,
                    TimeZoneId=appointment.TimeZoneId,
                    CustomField1=appointment.CustomField1
                });
        }

        public Appointments NoviRodjendan(int radnikID, DateTime datum)
        {
            RadnikService rs = new RadnikService();
            Radnik radnik = rs.GetByID(radnikID);
            Appointments rodjendan = new Appointments();
            rodjendan.Type = 1;
            rodjendan.StartDate = SharedService.StartOfDay(datum);
            rodjendan.EndDate = SharedService.EndOfDay(datum);
            rodjendan.AllDay = false;
            rodjendan.Subject = string.Format("Rođendan osobe {0} {1}",radnik.Prezime, radnik.Ime);
            rodjendan.Location = string.Empty;
            rodjendan.Description = string.Empty;
            rodjendan.Status = 0;
            rodjendan.Label = 8;//8 rodjendan, 9 godisnjica
            rodjendan.ResourceID = null;
            rodjendan.ResourceIDs = null;
            rodjendan.ReminderInfo = null;// string.Format("< Reminders >< Reminder AlertTime = '{0}' /></ Reminders >", datum);
            rodjendan.RecurrenceInfo =string.Format( @"<RecurrenceInfo Start=""{0}/{1}/{2} 00:00:00"" DayNumber=""{1}"" WeekOfMonth=""0"" WeekDays=""0"" Id =""{3}"" Month=""{0}"" Range=""1"" Type=""3"" Version =""1"" />",datum.Month,datum.Day,datum.Year, Guid.NewGuid());
            rodjendan.TimeZoneId = "Central European Standard Time";
            rodjendan.CustomField1 = radnikID.ToString();

            return rodjendan;
        }
        public Appointments NovaGodisnjica(int radnikID, DateTime datum, string opis)
        {
            RadnikService rs = new RadnikService();
            Radnik radnik = rs.GetByID(radnikID);
            Appointments godisnjica = new Appointments();
            godisnjica.Type = 1;
            godisnjica.StartDate = SharedService.StartOfDay(datum);
            godisnjica.EndDate = SharedService.EndOfDay(datum);
            godisnjica.AllDay = false;
            godisnjica.Subject = string.Format("{0} za radnika {1} {2}", opis, radnik.Prezime, radnik.Ime);
            godisnjica.Location = string.Empty;
            godisnjica.Description = opis;
            godisnjica.Status = 0;
            godisnjica.Label = 9;//8 rodjendan, 9 godisnjica
            godisnjica.ResourceID = null;
            godisnjica.ResourceIDs = null;
            godisnjica.ReminderInfo = null;// string.Format("< Reminders >< Reminder AlertTime = '{0}' /></ Reminders >", datum);
            godisnjica.RecurrenceInfo = string.Format(@"<RecurrenceInfo Start=""{0}/{1}/{2} 00:00:00"" DayNumber=""{1}"" WeekOfMonth=""0"" WeekDays=""0"" Id =""{3}"" Month=""{0}"" Range=""1"" Type=""3"" Version =""1"" />", datum.Month, datum.Day, datum.Year, Guid.NewGuid());
            godisnjica.TimeZoneId = "Central European Standard Time";
            godisnjica.CustomField1 = radnikID.ToString();

            return godisnjica;
        }
    }
}
