namespace BettingInformationSystem.Web.Controllers
{
    using System.Web.Mvc;

    using BettingInformationSystem.Data;
    using BettingInformationSystem.Data.Interfaces;

    public class BaseController : Controller
    {
        public BaseController()
            : this(new BettingInformationSystemData())
        {
        }

        public BaseController(IBettingInformationSystemData data)
        {
            this.Data = data;
        }

        public IBettingInformationSystemData Data { get; set; }
    }
}