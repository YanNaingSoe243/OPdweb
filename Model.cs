using AutoMapper;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;

namespace OPdWebApp
{
    public class Dbobject
    {
        public string PId { get; set; } = Guid.NewGuid().ToString("N").Substring(0, 15);
    }
    public class Dbobject1
    {
        public string OId { get; set; } = Guid.NewGuid().ToString("N").Substring(0, 15);
    }
    public class Person : Dbobject
    {
      

        [Display(Name = "First Name")]
        public string FirstName { get; set; }


        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        [EmailAddress]
        public string EmailAddress { get; set; }


        [Display(Name = "NRC Number")]
        public string NRC { get; set; }

        public IList<Address> address { get; set; } = new List<Address>();

        public GenderType Gender { get; set; } = GenderType.Male;
        [Display(Name = "BloodGroup")]
        public BloodType BloodType = BloodType.O;

        public DateTime? DateOfBirth { get; set; } = DateTime.Now;

        public Status Status { get; set; } = Status.Active;

        public string FullName => $"{this.FirstName + " " + this.LastName}";
        public string? Photo { get; set; }
        public bool Equals(Person other) =>
            EmailAddress == other.EmailAddress &&
             FullName == other.FullName;
        public string RegisteredDate { get; set; } = DateTime.Now.ToShortDateString();
        public string ShortBiography { get; set; }
        [JsonIgnore]
        public string QRCode { get; set; }

        public Patient patient { get; set; } = new Patient();
       
      
    }

    public class Address : Dbobject1
    {
      
        [Display(Name = "Phone No")]
        public string PhoneNo { get; set; }

        [Required]
        [Display(Name = "Mobile No")]
        public string ContactNo { get; set; }
        public string HomeNo { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; } = "Myanmar";
      
    }
    public enum Status
    {
        Active,
        Inactive
    }
    public enum GenderType
    {
        Male,
        Female
    }


    public class Patient : Dbobject1
    {



        public DateTime RegisterDate { get; set; } = DateTime.Now;
        public PatientType PatientType { get; set; } = PatientType.Inpatient;
        public string OPTCase { get; set; }
      
        public string Department { get; set; }
        public string PersonPId { get; set; }
        public ReferInfor ReferInfor { get; set; } = new ReferInfor();
        public PatientStatus patientStatus { get; set; } = PatientStatus.Registration;
        public int Temparture { get; set; }
        public int Weight { get; set; }
        public string Height { get; set; }
        public int UpperBloodPressure { get; set; }
        public int LowerBloodPressure { get; set; }
        public int PulseRate { get; set; }             
         public string hospital { get; set; }
        public int Age { get; set; }
        public string Complaint { get; set; }
        public string Surgical { get; set; }
        public string Examination { get; set; }
        public string Investigation { get; set; }
        public List<Drug> Drugs { get; set; } = new List<Drug>();
        public List<Diagnosis> Diagnosises { get; set; } = new List<Diagnosis>();
        public List<Treatment> Treatments { get; set; } = new List<Treatment>();
        public List<Charge> Charges { get; set; } = new List<Charge>();

        public int DrugFee => Drugs.Sum(x => Convert.ToInt32(x.TotalPrice));
        public int DiagnosisFee => Diagnosises.Sum(x => Convert.ToInt32(x.UnitPrice));
        public int ChargeFee => Charges.Sum(x => Convert.ToInt32(x.UnitPrice));
        public int Tax { get; set; }
        public int __v { get; set; }
       
        public int GrandTotal => DrugFee + Tax + DiagnosisFee + ChargeFee;
        public VirtualPerson PId { get; set; } = new VirtualPerson();
        public int AgeCalc(DateTime dateOfBirth)
        {
            if (dateOfBirth != null)
            {


                var today = DateTime.Today;

                var a = (today.Year * 100 + today.Month) * 100 + today.Day;
                var b = (dateOfBirth.Year * 100 + dateOfBirth.Month) * 100 + dateOfBirth.Day;

                return (a - b) / 10000;
            }
            else
            {
                return 0;
            }

        }
        public string loginuser { get; set; } 

    }
    public class VirtualPerson
    {
        public string PId { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }


        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        [EmailAddress]
        public string EmailAddress { get; set; }


        [Display(Name = "NRC Number")]
        public string NRC { get; set; }
        public string FullName => $"{this.FirstName + " " + this.LastName}";
        public GenderType Gender { get; set; } = GenderType.Male;
        [Display(Name = "BloodGroup")]
        public BloodType BloodType = BloodType.O;

      
        public DateTime? DateOfBirth { get; set; } = DateTime.Now;

        public Status Status { get; set; } = Status.Active;

      
        public string? Photo { get; set; }
        public bool Equals(Person other) =>
            EmailAddress == other.EmailAddress &&
             FullName == other.FullName;
        public string RegisteredDate { get; set; } = DateTime.Now.ToShortDateString();
        public string ShortBiography { get; set; }
        [JsonIgnore]
        public string QRCode { get; set; }

        public IList<Address> address { get; set; } = new List<Address>();
    }
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<VirtualPerson,Person>().ForMember(dest =>
            dest.PId,
            opt => opt.MapFrom(src => src.PId)).ForMember(c => c.address, option => option.Ignore()); //Map from Developer Object to DeveloperDTO Object

            CreateMap<Person,VirtualPerson>().ForMember(dest =>
            dest.PId,
           opt => opt.MapFrom(src => src.PId)).ForMember(c => c.address, option => option.Ignore());
        }
    }
    public class Drug : Dbobject1
    {
       
        public string Date { get; set; } = DateTime.Now.ToShortDateString();
        public string DrugName { get; set; }

        public string Quantity { get; set; }
        public string Strength { get; set; }
        public string Group { get; set; }
        public string Forms { get; set; }
        public int UnitPrice { get; set; }
        public int TotalPrice { get; set; }
       

    }
    public class Diagnosis : Dbobject1
    {
       
        public string DiagnosisName { get; set; }
        public string Result { get; set; }
        public string Date { get; set; } = DateTime.Now.ToShortDateString();

        public int UnitPrice { get; set; }
       


    }
    public class Treatment : Dbobject1
    {

       
        public string Text { get; set; }
        public string Date { get; set; } = DateTime.Now.ToShortDateString();


    }
    public class Charge : Dbobject1
    {

       
        public string Name { get; set; }

        public int UnitPrice { get; set; }
      
    }


    public class SiginModel 
    {
      
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        public bool PRemember { get; set; } = false;
     




    }
    public class LoginResult
    {
        public string id { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
        public string jwtBearer { get; set; }
      //  public Department department { get; set; }      
        public StaffRoleEnum role { get; set; } 

    }
    public class SiginUpReturn : Dbobject1
    {
        public string _id { get; set; }
        public string FullName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirmation Password is required.")]
        [Compare("Password", ErrorMessage = "Password and Confirmation Password must match.")]
        public string ConfirmPassword { get; set; }
     
        public StaffRoleEnum role { get; set; } = StaffRoleEnum.user;
        public string RegisterDate { get; set; } = DateTime.Now.ToShortDateString();
         public string Staff { get; set; } 
   
         public string department { get; set; } 
        public PermisionStatus Permition { get; set; } = PermisionStatus.False;

        public int __v { get; set; }

    }
    public class SiginUp : Dbobject1
    {
        public string _id { get; set; }
        public string FullName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirmation Password is required.")]
        [Compare("Password", ErrorMessage = "Password and Confirmation Password must match.")]
        public string ConfirmPassword { get; set; }

        public StaffRoleEnum role { get; set; } = StaffRoleEnum.user;
        public string RegisterDate { get; set; } = DateTime.Now.ToShortDateString();
        public Staff Staff { get; set; } = new Staff();

        public string department { get; set; }
        public PermisionStatus Permition { get; set; } = PermisionStatus.False;

        public int __v { get; set; }

    }
    public enum PatientType
    {
        Inpatient,
        Outpatient,
        Refer
    }
    public class ReferInfor : Dbobject1
    {
       
        public string HospitalName { get; set; } = "null";
        public string SaMaNumber { get; set; } = "null";
        public string DoctoreName { get; set; } = "null";
        public string Decription { get; set; } = "null";
        public string Case { get; set; } = "null";
        public DateTime ReferDate { get; set; } 
        public string StaffRoles { get; set; } = "null";
        public string ContactInformation { get; set; } = "null";
      
    }
    public class Department : Dbobject1
    {

      
        public string Name { get; set; }

        public string Description { get; set; }

        public bool Equals(Department other) => Name == other.Name;
       



    }



    public class StaffRole : Dbobject1
    {
       
        public int BsonId { get; set; }
        public string RoleName { get; set; }
      
        //ပါရဂူ,doctor,nurse,brother,public,private,HeadofDepartment,Technical,Admin

    }


    public class Staff : Dbobject1
    {

        public string FirstName { get; set; } = "New";


        [Display(Name = "Last Name")]
        public string LastName { get; set; } = "New";


        [Display(Name = "NRC Number")]
        public string NRC { get; set; } = "New";
        public string FullName => $"{this.FirstName + " " + this.LastName}";
        public GenderType Gender { get; set; } = GenderType.Male;
        [Display(Name = "BloodGroup")]
        public BloodType BloodType = BloodType.O;


        public DateTime? DateOfBirth { get; set; } = DateTime.Now;

        public Status Status { get; set; } = Status.Active;


        public string Photo { get; set; }
       
        public string RegisteredDate { get; set; } = DateTime.Now.ToShortDateString();
        public string ShortBiography { get; set; } = "New";
        [JsonIgnore]
        public string QRCode { get; set; }

        public IList<Address> address { get; set; } = new List<Address>();


    }


    public enum PatientStatus
    {
        Registration,
        Processing,
        Completed,

    }
public enum PermisionStatus
{
    True,
    False
   

}
public enum StaffRoleEnum
    {
        user,
        Admin,


    }
    public enum BloodType
    {
        O,
        A,
        Aplus,
        Bplus,
        AB,
        ABplus

    }

}
