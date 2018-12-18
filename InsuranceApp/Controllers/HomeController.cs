﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InsuranceApp.Models;
using InsuranceApp.ViewModels;

namespace InsuranceApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Quotes;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Quote(string FirstName, string LastName, string EmailAddress, string DateOfBirth, string CarYear, string CarMake, string CarModel, string SpeedingTickets, string DUI, string Coverage)
        {
            if (string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(LastName) || string.IsNullOrEmpty(EmailAddress) || string.IsNullOrEmpty(DateOfBirth) || string.IsNullOrEmpty(CarYear) || string.IsNullOrEmpty(CarMake) || string.IsNullOrEmpty(CarModel) || string.IsNullOrEmpty(SpeedingTickets) || string.IsNullOrEmpty(DUI) || string.IsNullOrEmpty(Coverage))

            {
                return View("~/Views/Shared/Error.cshtml");
            }

            else
            {
               
                DateTime Dob = Convert.ToDateTime(DateOfBirth);
                int age = 0;
                age = DateTime.Now.Year - Dob.Year;
                if (DateTime.Now.DayOfYear < Dob.DayOfYear)
                    age = age - 1;
                double total = 50;


                bool under25orOver100 = age < 25 || age > 100;
                if (under25orOver100)
                {
                    total = total + 25;
                }
                else if (age < 18)
                {
                    total = total + 100;
                }
                else
                {
                    total = 50;
                }


                int carYear = Convert.ToInt32(CarYear);


                if (carYear < 2000 || carYear > 2015)
                {
                    total = total + 25;
                }

                else
                {
                    total = total;
                }

                if (CarMake == "Porsche".ToLower())
                {
                    total = total + 25;
                }
                else
                {
                    total = total;
                }
                if (CarMake == "Porsche".ToLower() && CarModel == "911 Carrera".ToLower())
                {
                    total = total + 25;
                }
                else
                {
                    total = total;
                }

                int tickets = Convert.ToInt32(SpeedingTickets);

                int ticketTotal = tickets * 10;

                total = total + ticketTotal;

                bool Dui = DUI == "Yes".ToLower();
                if (Dui)
                {
                    total = total + (total * .25);
                }
                else
                {
                    total = total;
                }

                bool FullCoverage = Coverage == "Full Coverage".ToLower() || Coverage == "Full".ToLower();

                if (FullCoverage)
                {
                    total = total + (total * .5);
                }
                else
                {
                    total = total;
                }

               double Quote = total;

                ViewBag.Quote ="$"+ Quote;

                using (QuotesEntities db = new QuotesEntities())
                {
                    var Quotes = new Quotes();
                    Quotes.FirstName = FirstName;
                    Quotes.LastName = LastName;
                    Quotes.EmailAddress = EmailAddress;
                    string Quote1 = Convert.ToString(Quote);
                    Quotes.Quote = Quote1;

                    db.Quotes.Add(Quotes);
                    db.SaveChanges();

                    
                }

                    return View("Success");
            }
           
               
               }



            }
        }
    