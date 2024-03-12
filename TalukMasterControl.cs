using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using TalukMaster.BLayer;
using TalukMaster.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TalukMaster.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TalukMasterControl : ControllerBase
    {
        BLTaluk BL = new BLTaluk();
        TalukModel TM = new TalukModel();
        List<TalukModel> listObj = new List<TalukModel>() ;
        [HttpGet]
        [Route("AllTaluk")]
        public IActionResult GetAllTalukMaster()
        {

            listObj = BL.GetAllTalukMaster();


            return Ok(listObj);
        }

        [HttpGet]
        [Route("IDTaluk")]
        public IActionResult GetTalukNames([FromQuery] int DID)

        {
            listObj= BL.GetTalukMasterID(DID);
            return Ok(listObj);


        }

        [HttpPost]
        [Route("Save")]

        public IActionResult SaveDetails([FromQuery]int TID,string TName,int DID)
        {
            bool Result = BL.SavaTalukDetails(TID,TName, DID);
            return Result ? Ok("Data inserted successfully") : StatusCode(500);
        }

        [HttpPut]
        [Route("Update")]

        public IActionResult UpdateTDetails([FromQuery] int TID, string TName, int DID)
        {
            bool Result = BL.UpdateTDetails(TID, TName, DID);
            return Result ? Ok("Data Updated  successfully") : StatusCode(500);
        }

        [HttpDelete]
        [Route("Delete")]

        public IActionResult DeleteTDetails(int TID)
        {
            bool Result = BL.DeleteTDetails(TID);
            return Result ? Ok("Data Deleted  successfully") : StatusCode(500);
        }

       
    }
}
