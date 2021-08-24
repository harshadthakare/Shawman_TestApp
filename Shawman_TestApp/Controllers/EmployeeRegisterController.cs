using Shawman_TestApp.Models;
using Shawman_TestApp.EnityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shawman_TestApp.Controllers
{
    public class EmployeeRegisterController : Controller
    {
        // GET: EmployeeRegister
        Employee_HARSHADEntities db = new Employee_HARSHADEntities();

        public ActionResult Index()
        {
            EmployeeModel employeeModel = GetDDLDetails();


            return View(employeeModel);
        }

        [HttpPost]
        public ActionResult Index(EmployeeModel employee)
        {
            
            try
            {

                if (ModelState.IsValid)
                {
                    db.TblEmployees.Add(new TblEmployee()
                    {
                        Name = employee.Name,
                        DOB = employee.DateOfBirth,
                        Email = employee.Email,
                        MobileNo = employee.MobileNo,
                        DesignationId = employee.DesignationId.Value
                    });
                    db.SaveChanges();
                    return RedirectToAction("Index", "EmployeeRegister");
                }
                return RedirectToAction("Index", "EmployeeRegister"); ;
               
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]
        public ActionResult GetDetails()
        {
            List<EmployeeModel> employees = new List<EmployeeModel>();
            try
            {
                var result = db.TblEmployees
                        .Join(db.TblDesignations,
                          E => E.DesignationId,
                          D => D.DesignationId,
                          (E, D) => new
                          {
                             E.ID,
                             E.Name,
                             E.DOB,
                             E.Email,
                             E.MobileNo,
                             D.DesignationDesc
                          })
    
                        .ToList();
                if (result.Count > 0)
                {
                    foreach (var item in result)
                    {
                        employees.Add(new EmployeeModel
                        {
                            Id = item.ID,
                            Name = item.Name,
                            DateOfBirth = item.DOB,
                            Email = item.Email,
                            MobileNo = item.MobileNo,
                            Designation = item.DesignationDesc
                        });
                    }
                }

                return PartialView(employees);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet]
        public EmployeeModel GetDDLDetails()
        {
            List<DesignationModel> employees = new List<DesignationModel>();
            EmployeeModel employeeModel = new EmployeeModel();
            try
            {
                List<TblDesignation> result = db.TblDesignations.ToList();
                if (result.Count > 0)
                {
                    foreach (var item in result)
                    {
                        employees.Add(new DesignationModel
                        {
                            Id = item.DesignationId,
                            Name = item.DesignationDesc,
                         
                        });
                    }
                }
                employeeModel.designationModels = employees;
                return employeeModel;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}