using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;

namespace OPdWebApp.OPDInfo
{
    public partial class PatitentsComponent : ComponentBase
    {
        [Inject]
        protected IJSRuntime JSRuntime { get; set; }
        [Inject]
        protected NavigationManager UriHelper { get; set; }

        [Inject]
        protected NavigationManager navigationManager { get; set; }
        //protected override async System.Threading.Tasks.Task OnInitializedAsync()
        //{



        //}
        //protected IEnumerable<Person> persons { get; set; }
        protected PatitentsInfor addPatiten { get; set; }
        protected void AddPatitent()
        {

            //addPatiten.persons = persons; 
            addPatiten.Show();


        }
        protected ReportDetail reportDetail { get; set; }
        protected void ShowReprotDetail()
        {


            reportDetail.Show();



        }
    }
}
