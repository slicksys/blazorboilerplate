using System;
using Syncfusion.Blazor.Navigations;
using Syncfusion.Blazor.Schedule;
using System.Collections.Generic;
using System.Threading.Tasks;
using SSDCPortal.Theme.Material.Demo.Models;

namespace SSDCPortal.Theme.Material.Demo.Pages
{
    public class SchedulerBase : ComponentBase
    {
      
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (!firstRender) return;
            try
            {
                EventProcessing = true;
                var ct = getCancellationToken();


                Console.WriteLine("Finished OnAfterRenderAsync");


                StateHasChanged();
            }
            catch (OperationCanceledException) { }
            catch (Exception ex) { Console.WriteLine(ex); }
            finally { EventProcessing = false; }
        }

        public class ScheduleData
        {
            public List<AppointmentData> GetScheduleData()
            {
                List<AppointmentData> appData = new List<AppointmentData>();
                appData.Add(new AppointmentData
                {
                    Id = 1,
                    Subject = "Explosion of Betelgeuse Star",
                    Location = "Space Centre USA",
                    StartTime = new DateTime(2020, 1, 5, 9, 30, 0),
                    EndTime = new DateTime(2020, 1, 5, 11, 0, 0),
                    CategoryColor = "#1aaa55"
                });
                appData.Add(new AppointmentData
                {
                    Id = 2,
                    Subject = "Thule Air Crash Report",
                    Location = "Newyork City",
                    StartTime = new DateTime(2020, 1, 6, 12, 0, 0),
                    EndTime = new DateTime(2020, 1, 6, 14, 0, 0),
                    CategoryColor = "#357cd2"
                });

                return appData;
            }
            public List<ContextEventsData> GetContextEventData()
            {
                List<ContextEventsData> appData = new List<ContextEventsData>();
                appData.Add(new ContextEventsData
                {
                    Id = 1,
                    Subject = "Explosion of Betelgeuse Star",
                    Location = "Space Centre USA",
                    StartTime = new DateTime(2020, 1, 5, 9, 30, 0),
                    EndTime = new DateTime(2020, 1, 5, 11, 0, 0),
                    CategoryColor = "#1aaa55"
                });
                appData.Add(new ContextEventsData
                {
                    Id = 2,
                    Subject = "Thule Air Crash Report",
                    Location = "Newyork City",
                    StartTime = new DateTime(2020, 1, 6, 12, 0, 0),
                    EndTime = new DateTime(2020, 1, 6, 14, 0, 0),
                    CategoryColor = "#357cd2"
                });

                return appData;
            }
            public List<AppointmentData> GetZooEventData()
            {
                List<AppointmentData> zooEventData = new List<AppointmentData>();
                zooEventData.Add(new AppointmentData
                {
                    Id = 1,
                    Subject = "Story Time for Kids",
                    StartTime = new DateTime(2020, 1, 12, 10, 0, 0),
                    EndTime = new DateTime(2020, 1, 12, 11, 30, 0),
                    CategoryColor = "#1aaa55"
                });
                zooEventData.Add(new AppointmentData
                {
                    Id = 2,
                    Subject = "Camping with Turtles",
                    StartTime = new DateTime(2020, 1, 13, 12, 0, 0),
                    EndTime = new DateTime(2020, 1, 13, 14, 0, 0),
                    CategoryColor = "#357cd2"
                });

                return zooEventData;
            }
            public List<ReadonlyEventsData> GetReadonlyEventsData()
            {
                DateTime dateNow = DateTime.Now;
                DateTime dateNow1 = DateTime.Now.AddDays(-2);
                DateTime dateNow2 = DateTime.Now.AddDays(-1);
                DateTime dateNow3 = DateTime.Now.AddDays(1);
                DateTime dateNow4 = DateTime.Now.AddDays(2);
                List<ReadonlyEventsData> readonlyEventsData = new List<ReadonlyEventsData>();
                readonlyEventsData.Add(new ReadonlyEventsData
                {
                    Id = 1,
                    Subject = "Project Workflow Analysis",
                    StartTime = new DateTime(dateNow1.Year, dateNow1.Month, dateNow1.Day, dateNow1.AddHours(2).Hour, 0, 0),
                    EndTime = new DateTime(dateNow1.Year, dateNow1.Month, dateNow1.Day, dateNow1.AddHours(4).Hour, 0, 0),
                    IsReadonly = true
                });
                readonlyEventsData.Add(new ReadonlyEventsData
                {
                    Id = 2,
                    Subject = "Project Requirement Planning",
                    StartTime = new DateTime(dateNow2.Year, dateNow2.Month, dateNow2.Day, dateNow2.AddHours(2).Hour, 0, 0),
                    EndTime = new DateTime(dateNow2.Year, dateNow2.Month, dateNow2.Day, dateNow2.AddHours(4).Hour, 0, 0),
                    IsReadonly = true
                });
                readonlyEventsData.Add(new ReadonlyEventsData
                {
                    Id = 3,
                    Subject = "Meeting with Developers",
                    StartTime = new DateTime(dateNow2.Year, dateNow2.Month, dateNow2.Day, dateNow2.AddHours(-3).Hour, 0, 0),
                    EndTime = new DateTime(dateNow2.Year, dateNow2.Month, dateNow2.Day, dateNow2.AddHours(-1).Hour, 0, 0),
                    IsReadonly = true
                });

                return readonlyEventsData;
            }

            public List<ResourceData> GetResourceData()
            {
                List<ResourceData> resourceData = new List<ResourceData>();
                resourceData.Add(new ResourceData
                {
                    Id = 1,
                    Subject = "Workflow Analysis",
                    StartTime = new DateTime(2020, 1, 5, 9, 30, 0),
                    EndTime = new DateTime(2020, 1, 5, 12, 0, 0),
                    IsAllDay = false,
                    ProjectId = 1,
                    TaskId = 2
                });
                resourceData.Add(new ResourceData
                {
                    Id = 2,
                    Subject = "Requirement planning",
                    StartTime = new DateTime(2020, 1, 5, 12, 30, 0),
                    EndTime = new DateTime(2020, 1, 5, 14, 45, 0),
                    IsAllDay = false,
                    ProjectId = 1,
                    TaskId = 1
                });
                resourceData.Add(new ResourceData
                {
                    Id = 3,
                    Subject = "Quality Analysis",
                    StartTime = new DateTime(2020, 1, 6, 10, 0, 0),
                    EndTime = new DateTime(2020, 1, 6, 12, 30, 0),
                    IsAllDay = false,
                    ProjectId = 1,
                    TaskId = 1
                });

                return resourceData;
            }
            public List<ResourceConferenceData> GetResourceConferenceData()
            {
                List<ResourceConferenceData> resourceConferenceData = new List<ResourceConferenceData>();
                resourceConferenceData.Add(new ResourceConferenceData
                {
                    Id = 1,
                    Subject = "Burning Man",
                    StartTime = new DateTime(2020, 1, 3, 15, 0, 0),
                    EndTime = new DateTime(2020, 1, 3, 17, 0, 0),
                    ConferenceId = new int[] { 1, 2, 3 }
                });
                resourceConferenceData.Add(new ResourceConferenceData
                {
                    Id = 2,
                    Subject = "Data-Driven Economy",
                    StartTime = new DateTime(2020, 1, 4, 12, 0, 0),
                    EndTime = new DateTime(2020, 1, 4, 14, 0, 0),
                    ConferenceId = new int[] { 1, 2 }
                });
                resourceConferenceData.Add(new ResourceConferenceData
                {
                    Id = 3,
                    Subject = "Techweek",
                    StartTime = new DateTime(2020, 1, 4, 15, 0, 0),
                    EndTime = new DateTime(2020, 1, 4, 17, 0, 0),
                    ConferenceId = new int[] { 2, 3 }
                });

                return resourceConferenceData;
            }
            public List<ResourceTeamData> GetResourceTeamData()
            {
                List<ResourceTeamData> resourceTeamData = new List<ResourceTeamData>();
                resourceTeamData.Add(new ResourceTeamData
                {
                    Id = 1,
                    Subject = "Developers Meeting",
                    StartTime = new DateTime(2020, 1, 3, 10, 0, 0),
                    EndTime = new DateTime(2020, 1, 3, 11, 0, 0),
                    RecurrenceRule = "FREQ=WEEKLY;INTERVAL=1;BYDAY=MO,TU,WE,TH,FR",
                    ProjectId = 1,
                    CategoryId = 1
                });
                resourceTeamData.Add(new ResourceTeamData
                {
                    Id = 2,
                    Subject = "Test report Validation",
                    StartTime = new DateTime(2020, 1, 4, 10, 30, 0),
                    EndTime = new DateTime(2020, 1, 4, 13, 0, 0),
                    RecurrenceRule = "FREQ=WEEKLY;INTERVAL=1;BYDAY=MO,WE,FR",
                    ProjectId = 1,
                    CategoryId = 2
                });
                resourceTeamData.Add(new ResourceTeamData
                {
                    Id = 3,
                    Subject = "Requirement planning",
                    StartTime = new DateTime(2020, 1, 6, 9, 30, 0),
                    EndTime = new DateTime(2020, 1, 6, 10, 45, 0),
                    RecurrenceRule = "FREQ=WEEKLY;INTERVAL=1;BYDAY=MO,TU,WE,TH,FR",
                    ProjectId = 2,
                    CategoryId = 1
                });
                resourceTeamData.Add(new ResourceTeamData
                {
                    Id = 4,
                    Subject = "Bug Automation",
                    StartTime = new DateTime(2020, 1, 4, 11, 0, 0),
                    EndTime = new DateTime(2020, 1, 4, 13, 0, 0),
                    RecurrenceRule = "FREQ=WEEKLY;INTERVAL=1;BYDAY=MO,WE,FR",
                    ProjectId = 2,
                    CategoryId = 2
                });

                return resourceTeamData;
            }
            public List<RoomData> GetRoomData()
            {
                List<RoomData> roomData = new List<RoomData>();
                roomData.Add(new RoomData
                {
                    Id = 1,
                    Subject = "Board Meeting",
                    Description = "Meeting to discuss business goal of 2020.",
                    StartTime = new DateTime(2019, 12, 30, 9, 0, 0),
                    EndTime = new DateTime(2019, 12, 30, 11, 0, 0),
                    RoomId = 1
                });
                roomData.Add(new RoomData
                {
                    Id = 2,
                    Subject = "Training session on JSP",
                    Description = "Knowledge sharing on JSP topics.",
                    StartTime = new DateTime(2019, 12, 30, 15, 0, 0),
                    EndTime = new DateTime(2019, 12, 30, 17, 0, 0),
                    RoomId = 5
                });
                roomData.Add(new RoomData
                {
                    Id = 3,
                    Subject = "Sprint Planning with Team members",
                    Description = "Planning tasks for sprint.",
                    StartTime = new DateTime(2019, 12, 30, 9, 30, 0),
                    EndTime = new DateTime(2019, 12, 30, 11, 0, 0),
                    RoomId = 3
                });

                return roomData;
            }
            public List<RoomData> GetRoomsData()
            {
                List<RoomData> roomData = new List<RoomData>();
                roomData.Add(new RoomData
                {
                    Id = 1,
                    Subject = "Board Meeting",
                    Description = "Meeting to discuss business goal of 2020.",
                    StartTime = new DateTime(2020, 1, 5, 9, 30, 0),
                    EndTime = new DateTime(2020, 1, 5, 11, 0, 0),
                    RoomId = 10
                });
                roomData.Add(new RoomData
                {
                    Id = 2,
                    Subject = "Training session on JSP",
                    Description = "Knowledge sharing on JSP topics.",
                    StartTime = new DateTime(2020, 1, 7, 9, 30, 0),
                    EndTime = new DateTime(2020, 1, 7, 11, 0, 0),
                    RoomId = 8
                });
                roomData.Add(new RoomData
                {
                    Id = 3,
                    Subject = "Sprint Planning with Team members",
                    Description = "Planning tasks for sprint.",
                    StartTime = new DateTime(2020, 1, 9, 9, 30, 0),
                    EndTime = new DateTime(2020, 1, 9, 11, 0, 0),
                    RoomId = 3
                });

                return roomData;
            }
            public List<GroomingData> GetGroomingData()
            {
                List<GroomingData> hospitalData = new List<GroomingData>();

                hospitalData.Add(new GroomingData
                {
                    Id = 10,
                    Name = "David",
                    StartTime = new DateTime(2020, 1, 6, 9, 0, 0),
                    EndTime = new DateTime(2020, 1, 6, 10, 0, 0),
                    Description = "Health Checkup",
                    DepartmentID = 1,
                    ConsultantID = 1,
                    DepartmentName = "GENERAL"
                });
                hospitalData.Add(new GroomingData
                {
                    Id = 11,
                    Name = "John",
                    StartTime = new DateTime(2020, 1, 6, 10, 30, 0),
                    EndTime = new DateTime(2020, 1, 6, 11, 30, 0),
                    Description = "Tooth Erosion",
                    DepartmentID = 2,
                    ConsultantID = 2,
                    DepartmentName = "DENTAL"
                });

                return hospitalData;
            }

            public List<GroomingData> GetWaitingListData()
            {
                List<GroomingData> waitingData = new List<GroomingData>();
                waitingData.Add(new GroomingData
                {
                    Id = 1,
                    Name = "Steven",
                    StartTime = new DateTime(2020, 1, 3, 7, 30, 0),
                    EndTime = new DateTime(2020, 1, 3, 9, 30, 0),
                    Description = "Consulting",
                    DepartmentName = "GENERAL"
                });
                waitingData.Add(new GroomingData
                {
                    Id = 2,
                    Name = "Milan",
                    StartTime = new DateTime(2020, 1, 4, 8, 30, 0),
                    EndTime = new DateTime(2020, 1, 4, 10, 30, 0),
                    Description = "Bad Breath",
                    DepartmentName = "DENTAL"
                });
                waitingData.Add(new GroomingData
                {
                    Id = 3,
                    Name = "Laura",
                    StartTime = new DateTime(2020, 1, 4, 9, 30, 0),
                    EndTime = new DateTime(2020, 1, 4, 10, 30, 0),
                    Description = "Extraction",
                    DepartmentName = "GENERAL"
                });

                return waitingData;
            }
            public List<AppointmentData> GetHeaderRowData()
            {
                List<AppointmentData> headerRowData = new List<AppointmentData>();

                return headerRowData;
            }
            public List<BlockData> GetBlockData()
            {
                List<BlockData> blockData = new List<BlockData>();
                blockData.Add(new BlockData
                {
                    Id = 1,
                    Subject = "Not Available",
                    StartTime = new DateTime(2020, 1, 1, 10, 0, 0),
                    EndTime = new DateTime(2020, 1, 1, 12, 0, 0),
                    IsAllDay = false,
                    IsBlock = true,
                    EmployeeId = 1
                });
                blockData.Add(new BlockData
                {
                    Id = 2,
                    Subject = "Not Available",
                    StartTime = new DateTime(2020, 1, 1, 16, 0, 0),
                    EndTime = new DateTime(2020, 1, 1, 20, 0, 0),
                    IsAllDay = false,
                    IsBlock = true,
                    EmployeeId = 2
                });
                blockData.Add(new BlockData
                {
                    Id = 3,
                    Subject = "Not Available",
                    StartTime = new DateTime(2020, 1, 1, 12, 0, 0),
                    EndTime = new DateTime(2020, 1, 1, 14, 0, 0),
                    IsAllDay = false,
                    IsBlock = true,
                    EmployeeId = 3
                });

                return blockData;
            }
            public List<AppointmentData> GetRecurrenceData()
            {
                List<AppointmentData> recurrenceData = new List<AppointmentData>();
                recurrenceData.Add(new AppointmentData
                {
                    Id = 1,
                    Subject = "Project demo meeting with Andrew",
                    Location = "Office",
                    StartTime = new DateTime(2020, 1, 8, 12, 0, 0),
                    EndTime = new DateTime(2020, 1, 8, 13, 0, 0),
                    RecurrenceRule = "FREQ=WEEKLY;INTERVAL=2;BYDAY=MO;COUNT=10",
                    CategoryColor = "#1aaa55",
                    Description = "Project demo meeting with Andrew regarding timeline"
                });
                recurrenceData.Add(new AppointmentData
                {
                    Id = 2,
                    Subject = "Scrum Meeting",
                    Location = "Office",
                    StartTime = new DateTime(2020, 1, 6, 9, 30, 0),
                    EndTime = new DateTime(2020, 1, 6, 10, 30, 0),
                    RecurrenceRule = "FREQ=DAILY;INTERVAL=1;COUNT=10",
                    CategoryColor = "#357cd2",
                    Description = "Weekly work status"
                });

                return recurrenceData;
            }
            public List<FifaEventsData> GetFifaEventsData()
            {
                List<FifaEventsData> fifaEventsData = new List<FifaEventsData>();
                fifaEventsData.Add(new FifaEventsData
                {
                    Id = 1,
                    Subject = "RUSSIA vs SAUDI ARABIA",
                    Description = "Group A",
                    StartTime = new DateTime(2020, 1, 16, 15, 0, 0),
                    EndTime = new DateTime(2020, 1, 16, 17, 0, 0),
                    StartTimezone = "Europe/Moscow",
                    EndTimezone = "Europe/Moscow",
                    City = "Moscow",
                    CategoryColor = "#1aaa55",
                    GroupId = 1
                });
                fifaEventsData.Add(new FifaEventsData
                {
                    Id = 2,
                    Subject = "EGYPT vs URUGUAY",
                    Description = "Group A",
                    StartTime = new DateTime(2020, 1, 17, 12, 0, 0),
                    EndTime = new DateTime(2020, 1, 17, 14, 0, 0),
                    StartTimezone = "Asia/Yekaterinburg",
                    EndTimezone = "Asia/Yekaterinburg",
                    City = "Ekaterinburg",
                    CategoryColor = "#1aaa55",
                    GroupId = 1
                });
                fifaEventsData.Add(new FifaEventsData
                {
                    Id = 3,
                    Subject = "MOROCCO vs IR IRAN",
                    Description = "Group B",
                    StartTime = new DateTime(2020, 1, 17, 15, 0, 0),
                    EndTime = new DateTime(2020, 1, 17, 17, 0, 0),
                    StartTimezone = "Europe/Moscow",
                    EndTimezone = "Europe/Moscow",
                    City = "Saint Petersburg",
                    CategoryColor = "#357cd2",
                    GroupId = 2
                });

                return fifaEventsData;
            }
            public List<DoctorsEventData> GetDoctorsEventData()
            {
                List<DoctorsEventData> doctorsEventData = new List<DoctorsEventData>();
                doctorsEventData.Add(new DoctorsEventData
                {
                    Id = 1,
                    Subject = "Surgery - Andrew",
                    EventType = "Confirmed",
                    StartTime = new DateTime(2020, 1, 13, 9, 0, 0, 0),
                    EndTime = new DateTime(2020, 1, 13, 10, 0, 0)
                });
                doctorsEventData.Add(new DoctorsEventData
                {
                    Id = 2,
                    Subject = "Consulting - John",
                    EventType = "Confirmed",
                    StartTime = new DateTime(2020, 1, 13, 10, 0, 0),
                    EndTime = new DateTime(2020, 1, 13, 11, 30, 0)
                });

                return doctorsEventData;
            }
            public List<WebinarData> GetWebinarData()
            {
                List<WebinarData> webinarData = new List<WebinarData>();
                webinarData.Add(new WebinarData
                {
                    Id = 1,
                    Subject = "Environment Day",
                    Tags = "Eco day, Forest conserving, Earth & its resources",
                    Description = "A day that creates awareness to promote the healthy planet and reduce the air pollution crisis on nature earth.",
                    StartTime = new DateTime(2020, 1, 13, 9, 0, 0),
                    EndTime = new DateTime(2020, 1, 13, 14, 0, 0),
                    ImageName = "environment-day",
                    PrimaryColor = "#1aaa55",
                    SecondaryColor = "#47bb76"
                });
                webinarData.Add(new WebinarData
                {
                    Id = 2,
                    Subject = "Health Day",
                    Tags = "Reduce mental stress, Follow good food habits",
                    Description = "A day that raises awareness on different health issues. It marks the anniversary of the foundation of WHO.",
                    StartTime = new DateTime(2020, 1, 14, 9, 0, 0),
                    EndTime = new DateTime(2020, 1, 14, 14, 0, 0),
                    ImageName = "health-day",
                    PrimaryColor = "#357cd2",
                    SecondaryColor = "#5d96db"
                });

                return webinarData;
            }
            public List<EventsData> GetEventsData()
            {
                List<EventsData> eventsData = new List<EventsData>();
                eventsData.Add(new EventsData
                {
                    Id = 1,
                    Subject = "Server Maintenance",
                    StartTime = new DateTime(2020, 1, 12, 10, 0, 0),
                    EndTime = new DateTime(2020, 1, 12, 11, 30, 0),
                    EventType = "maintenance",
                    City = "Seattle",
                    CategoryColor = "#1aaa55"
                });
                eventsData.Add(new EventsData
                {
                    Id = 2,
                    Subject = "Art & Painting Gallery",
                    StartTime = new DateTime(2020, 1, 13, 12, 0, 0),
                    EndTime = new DateTime(2020, 1, 13, 14, 0, 0),
                    EventType = "public-event",
                    City = "Costa Rica",
                    CategoryColor = "#357cd2"
                });

                return eventsData;
            }
            public List<AppointmentData> GetEmployeeEventData()
            {
                List<AppointmentData> employeeEventData = new List<AppointmentData>();
                employeeEventData.Add(new AppointmentData
                {
                    Id = 1,
                    Subject = "Project Workflow Analysis",
                    StartTime = new DateTime(2020, 1, 13, 9, 0, 0),
                    EndTime = new DateTime(2020, 1, 13, 11, 0, 0),
                    CategoryColor = "#1aaa55"
                });
                employeeEventData.Add(new AppointmentData
                {
                    Id = 2,
                    Subject = "Project Requirement Planning",
                    StartTime = new DateTime(2020, 1, 14, 11, 30, 0),
                    EndTime = new DateTime(2020, 1, 14, 14, 0, 0),
                    CategoryColor = "#357cd2"
                });
                employeeEventData.Add(new AppointmentData
                {
                    Id = 3,
                    Subject = "Quality Analysis",
                    StartTime = new DateTime(2020, 1, 15, 9, 30, 0),
                    EndTime = new DateTime(2020, 1, 15, 11, 0, 0),
                    CategoryColor = "#7fa900"
                });

                return employeeEventData;
            }
            public List<ResourceEventsData> GetHolidayData()
            {
                List<ResourceEventsData> holidayData = new List<ResourceEventsData>();
                holidayData.Add(new ResourceEventsData
                {
                    Id = 401,
                    Subject = "Global Family Day",
                    StartTime = new DateTime(2020, 1, 1),
                    EndTime = new DateTime(2020, 1, 2),
                    IsAllDay = true,
                    CalendarId = 4
                });
                holidayData.Add(new ResourceEventsData
                {
                    Id = 402,
                    Subject = "World Braille Day",
                    StartTime = new DateTime(2020, 1, 4),
                    EndTime = new DateTime(2020, 1, 5),
                    IsAllDay = true,
                    CalendarId = 4
                });

                return holidayData;
            }

            public List<ResourceEventsData> GetBirthdayData()
            {
                List<ResourceEventsData> birthdayData = new List<ResourceEventsData>();
                birthdayData.Add(new ResourceEventsData
                {
                    Id = 301,
                    Subject = "Gladys Spellman",
                    StartTime = new DateTime(2020, 3, 1),
                    EndTime = new DateTime(2020, 3, 2),
                    IsAllDay = true,
                    CalendarId = 3
                });
                birthdayData.Add(new ResourceEventsData
                {
                    Id = 302,
                    Subject = "Susanna Salter",
                    StartTime = new DateTime(2020, 3, 2),
                    EndTime = new DateTime(2020, 3, 3),
                    IsAllDay = true,
                    CalendarId = 3
                });

                return birthdayData;
            }

            public List<ResourceEventsData> GetCompanyData()
            {
                List<ResourceEventsData> companyData = new List<ResourceEventsData>();
                companyData.Add(new ResourceEventsData
                {
                    Id = 201,
                    Subject = "Conference meeting",
                    StartTime = new DateTime(2020, 3, 1),
                    EndTime = new DateTime(2020, 3, 2),
                    IsAllDay = true,
                    CalendarId = 2
                });
                companyData.Add(new ResourceEventsData
                {
                    Id = 202,
                    Subject = "Product discussion",
                    StartTime = new DateTime(2020, 3, 4),
                    EndTime = new DateTime(2020, 3, 5),
                    IsAllDay = true,
                    CalendarId = 2
                });

                return companyData;
            }

            public List<ResourceEventsData> GetPersonalData()
            {
                List<ResourceEventsData> personalData = new List<ResourceEventsData>();
                personalData.Add(new ResourceEventsData
                {
                    Id = 101,
                    Subject = "Father Birthday",
                    StartTime = new DateTime(2020, 3, 1),
                    EndTime = new DateTime(2020, 3, 2),
                    IsAllDay = true,
                    CalendarId = 1
                });
                personalData.Add(new ResourceEventsData
                {
                    Id = 102,
                    Subject = "Engagement day",
                    StartTime = new DateTime(2020, 3, 4),
                    EndTime = new DateTime(2020, 3, 5),
                    IsAllDay = true,
                    CalendarId = 1
                });
                return personalData;
            }

            public List<DoctorData> GetDoctorData()
            {
                List<DoctorData> doctorData = new List<DoctorData>();
                doctorData.Add(new DoctorData
                {
                    Id = 1,
                    Subject = "Echocardiogram",
                    StartTime = new DateTime(2020, 3, 2, 9, 30, 0),
                    EndTime = new DateTime(2020, 3, 2, 11, 30, 0),
                    IsAllDay = false,
                    DoctorId = 1
                });
                doctorData.Add(new DoctorData
                {
                    Id = 2,
                    Subject = "Lumbar punctures",
                    StartTime = new DateTime(2020, 3, 2, 9, 30, 0),
                    EndTime = new DateTime(2020, 3, 2, 10, 45, 0),
                    IsAllDay = false,
                    DoctorId = 2
                });

                return doctorData;
            }

            public List<ResourceSampleData> GetResourceSampleData()
            {
                List<ResourceSampleData> data = new List<ResourceSampleData>();
                data.Add(new ResourceSampleData
                {
                    Id = 1,
                    Subject = "Burning Man",
                    StartTime = new DateTime(2020, 5, 29, 15, 0, 0),
                    EndTime = new DateTime(2020, 5, 29, 17, 0, 0),
                    OwnerId = 1
                });
                data.Add(new ResourceSampleData
                {
                    Id = 2,
                    Subject = "Marketing Forum",
                    StartTime = new DateTime(2020, 5, 31, 10, 0, 0),
                    EndTime = new DateTime(2020, 5, 31, 11, 30, 0),
                    OwnerId = 2
                });
                data.Add(new ResourceSampleData
                {
                    Id = 3,
                    Subject = "Business Factory",
                    StartTime = new DateTime(2020, 5, 31, 13, 30, 0),
                    EndTime = new DateTime(2020, 5, 31, 15, 0, 0),
                    OwnerId = 3
                });

                return data;
            }

            public class AppointmentData
            {
                public int Id { get; set; }
                public string Subject { get; set; }
                public string Location { get; set; }
                public string Description { get; set; }
                public DateTime StartTime { get; set; }
                public DateTime EndTime { get; set; }
                public Nullable<bool> IsAllDay { get; set; }
                public string CategoryColor { get; set; }
                public string RecurrenceRule { get; set; }
                public Nullable<int> RecurrenceID { get; set; }
                public Nullable<int> FollowingID { get; set; }
                public string RecurrenceException { get; set; }
                public string StartTimezone { get; set; }
                public string EndTimezone { get; set; }
            }
            public class ContextEventsData : AppointmentData
            {
                public virtual Guid Guid { get; set; }
            }
            public class ReadonlyEventsData : AppointmentData
            {
                public bool IsReadonly { get; set; }
            }
            public class ResourceData : AppointmentData
            {
                public int ProjectId { get; set; }
                public int TaskId { get; set; }
            }
            public class BlockData : AppointmentData
            {
                public bool IsBlock { get; set; }
                public int EmployeeId { get; set; }
            }
            public class EmployeeData
            {
                public string Text { get; set; }
                public int Id { get; set; }
                public int GroupId { get; set; }
                public string Color { get; set; }
                public string Designation { get; set; }
            }
            public class ResourceConferenceData : AppointmentData
            {
                public int[] ConferenceId { get; set; }
            }
            public class ConferenceData
            {
                public string Text { get; set; }
                public int Id { get; set; }
                public string Color { get; set; }
                public string Designation { get; set; }
            }
            public class RoomData : AppointmentData
            {
                public int RoomId { get; set; }
                public bool IsBlock { get; set; }
                public virtual string ElementType { get; set; }
                public virtual DateTime? StartTimeValue { get; set; }
                public virtual DateTime? EndTimeValue { get; set; }
            }
            public class RoomsData
            {
                public string Name { get; set; }
                public int? Id { get; set; }
                public int Capacity { get; set; }
                public string Color { get; set; }
                public string Type { get; set; }
            }
            public class ResourceTeamData : AppointmentData
            {
                public int ProjectId { get; set; }
                public int CategoryId { get; set; }
            }
            public class GroomingData : AppointmentData
            {
                public string Name { get; set; }
                public int DepartmentID { get; set; }
                public int ConsultantID { get; set; }
                public string DepartmentName { get; set; }
            }
            public class FifaEventsData : AppointmentData
            {
                public string City { get; set; }
                public int GroupId { get; set; }
            }
            public class DoctorsEventData : AppointmentData
            {
                public string EventType { get; set; }
            }
            public class WebinarData : AppointmentData
            {
                public string Tags { get; set; }
                public string ImageName { get; set; }
                public string PrimaryColor { get; set; }
                public string SecondaryColor { get; set; }
            }
            public class EventsData : AppointmentData
            {
                public string EventType { get; set; }
                public string City { get; set; }
            }
            public class ResourceEventsData : AppointmentData
            {
                public int CalendarId { get; set; }
            }
            public class DoctorData : AppointmentData
            {
                public int DoctorId { get; set; }
            }
            public class ResourceSampleData : AppointmentData
            {
                public int OwnerId { get; set; }
            }
        }

        protected override void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
