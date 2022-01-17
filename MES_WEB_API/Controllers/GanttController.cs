using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using MES_WEB_API.Models;

namespace MES_WEB_API.Controllers
{
    [RoutePrefix("Gantt")]
    public class GanttController : Controller
    {
        EqpPlanDAC db = new EqpPlanDAC();
        List<EqpStep> list;
        ArrayList eqpPlan = new ArrayList();
        //
        // Default Action
        //
        public ActionResult Index(string EQP ="", string Product="")
        {
            //if (Session["Email"] == null)
            //    return RedirectToAction("Index", "UserLogin");

            SelectCategory();

            list = db.GetEqpPlan();
            if (!string.IsNullOrWhiteSpace(EQP))
            {
                if (!string.IsNullOrWhiteSpace(Product))
                {
                    list = list.FindAll((x) => x.STEP_ID == EQP && x.id.Contains(Product));
                }
                else
                    list = list.FindAll((x) => x.STEP_ID == EQP);
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(Product))
                    list = list.FindAll((x) => x.id.Contains(Product));
            }

            var stepNum = list.GroupBy(o => new { o.STEP_ID })
               .Select(o => o.FirstOrDefault());
            var eqpNum = list.GroupBy(o => new { o.name })
               .Select(o => o.FirstOrDefault());

            foreach (var item in stepNum)
            {
                eqpPlan.Add(new
                {
                    id = item.STEP_ID,
                    name = item.STEP_ID

                });
                foreach (var eqp in eqpNum.Where((x) => x.STEP_ID == item.STEP_ID))
                {
                    var elist = list.FindAll(x => x.name == eqp.name);
                    ArrayList ePlan = new ArrayList();
                    for (int i = 0; i < elist.Count; i++)
                    {
                        if (elist[i].MACHINE_STATE == "SETUP")
                        {
                            ePlan.Add(new
                            {
                                id = "SETUP",
                                start = elist[i].start,
                                end = elist[i].end,
                                stroke = "#B8AA96",
                                fill = new
                                {
                                    angle = 90,
                                    keys = new[] {
                                    new { color = "#CFC0A9", position = 0 },
                                    new {color= "#E6D5BC",position= 1},
                                    new {color= "#E8D9C3",position= 1}
                                }
                                }
                            });
                        }
                        else
                        {
                            if (elist[i].id.Contains("STARBUCKS"))
                            {
                                ePlan.Add(new
                                {
                                    id = elist[i].id,
                                    start = elist[i].start,
                                    end = elist[i].end,
                                    stroke = "#B8AA96",
                                    fill = new
                                    {
                                        angle = 90,
                                        keys = new[] {
                                    new { color = "#006400", position = 1 }
                                }
                                    }
                                });
                            }
                            else if (elist[i].id.Contains("KANU"))
                            {
                                ePlan.Add(new
                                {
                                    id = elist[i].id,
                                    start = elist[i].start,
                                    end = elist[i].end,
                                    stroke = "#B8AA96",
                                    fill = new
                                    {
                                        angle = 90,
                                        keys = new[] {
                                    new { color = "#DC143C", position = 1 }
                                }
                                    }
                                });
                            }
                            else if (elist[i].id.Contains("TOMNTOMS"))
                            {
                                ePlan.Add(new
                                {
                                    id = elist[i].id,
                                    start = elist[i].start,
                                    end = elist[i].end,
                                    stroke = "#B8AA96",
                                    fill = new
                                    {
                                        angle = 90,
                                        keys = new[] {
                                    new { color = "#CD853F", position = 1 }
                                }
                                    }
                                });
                            }
                            else
                            {
                                ePlan.Add(new
                                {
                                    id = elist[i].id,
                                    start = elist[i].start,
                                    end = elist[i].end,
                                });
                            }

                        }

                    }
                    eqpPlan.Add(new
                    {
                        id = eqp.name,
                        name = eqp.name,
                        periods = ePlan,
                        parent = item.STEP_ID
                    });
                }
            }

            //string json = JsonConvert.SerializeObject(eqpPlan.ToArray(), Formatting.Indented);
            ViewBag.Data = eqpPlan;

            return PartialView();
        }


        //Get : https://localhost:44370/Gantt/LoadEqpPlan/PAINT/StarBucks/
        [HttpGet]
        [Route("LoadEqpPlan/{EQP}/{Product}")]
        public JsonResult LoadEqpPlan(string EQP = null, string Product = null)
        {
            list = db.GetEqpPlan();
            if (EQP != null)
            {
                if (Product != null)
                {
                    list = list.FindAll((x) => x.STEP_ID == EQP && x.name == Product);
                }
                else
                    list = list.FindAll((x) => x.STEP_ID == EQP);
            }
            else
            {
                if (Product != null)
                    list = list.FindAll((x) => x.name == Product);
            }

            var stepNum = list.GroupBy(o => new { o.STEP_ID })
               .Select(o => o.FirstOrDefault());
            var eqpNum = list.GroupBy(o => new { o.name })
               .Select(o => o.FirstOrDefault());

            foreach (var item in stepNum)
            {
                eqpPlan.Add(new
                {
                    id = item.STEP_ID,
                    name = item.STEP_ID

                });
                foreach (var eqp in eqpNum.Where((x) => x.STEP_ID == item.STEP_ID))
                {
                    var elist = list.FindAll(x => x.name == eqp.name);
                    ArrayList ePlan = new ArrayList();
                    for (int i = 0; i < elist.Count; i++)
                    {
                        if(elist[i].MACHINE_STATE =="SETUP")
                        {
                            ePlan.Add(new
                            {
                                id = "SETUP",
                                start = elist[i].start,
                                end = elist[i].end,
                                stroke = "#B8AA96",
                                fill = new
                                {
                                    angle = 90,
                                    keys = new[] {
                                    new { color = "#CFC0A9", position = 0 },
                                    new {color= "#E6D5BC",position= 1},
                                    new {color= "#E8D9C3",position= 1}
                                }
                                }
                            });
                        }
                        else 
                        {
                            if (elist[i].id.Contains("STARBUCKS"))
                            {
                                ePlan.Add(new
                                {
                                    id = elist[i].id,
                                    start = elist[i].start,
                                    end = elist[i].end,
                                    stroke = "#B8AA96",
                                    fill = new
                                    {
                                        angle = 90,
                                        keys = new[] {
                                    new { color = "#006400", position = 1 }
                                }
                                    }
                                });
                            }
                            else if (elist[i].id.Contains("KANU"))
                            {
                                ePlan.Add(new
                                {
                                    id = elist[i].id,
                                    start = elist[i].start,
                                    end = elist[i].end,
                                    stroke = "#B8AA96",
                                    fill = new
                                    {
                                        angle = 90,
                                        keys = new[] {
                                    new { color = "#DC143C", position = 1 }
                                }
                                    }
                                });
                            }
                            else if (elist[i].id.Contains("TOMNTOMS"))
                            {
                                ePlan.Add(new
                                {
                                    id = elist[i].id,
                                    start = elist[i].start,
                                    end = elist[i].end,
                                    stroke = "#B8AA96",
                                    fill = new
                                    {
                                        angle = 90,
                                        keys = new[] {
                                    new { color = "#CD853F", position = 1 }
                                }
                                    }
                                });
                            }
                            else
                            {
                                ePlan.Add(new
                                {
                                    id = elist[i].id,
                                    start = elist[i].start,
                                    end = elist[i].end,                                  
                                });
                            }

                        }
                        
                    }
                    eqpPlan.Add(new
                    {
                        id = eqp.name,
                        name = eqp.name,
                        periods = ePlan,
                        parent = item.STEP_ID
                    });
                }
            }
            ViewBag.Data = Json(eqpPlan, JsonRequestBehavior.AllowGet);

            return Json(eqpPlan, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Lot(string EQP = "", string Product = "")
        {

            SelectCategory();
            list = db.GetLotPlan();

            if (!string.IsNullOrWhiteSpace(EQP))
            {
                if (!string.IsNullOrWhiteSpace(Product))
                {
                    list = list.FindAll((x) => x.STEP_ID == EQP && x.id.Contains(Product));
                }
                else
                    list = list.FindAll((x) => x.STEP_ID == EQP);
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(Product))
                    list = list.FindAll((x) => x.id.Contains(Product));
            }

            var lotNum = list.GroupBy(o => new { o.name })
               .Select(o => o.FirstOrDefault());

            int seed = 0;
            foreach (var item in lotNum)
            {
                    var elist = list.FindAll(x => x.name == item.name);
                    ArrayList ePlan = new ArrayList();
                    
                    var random = new Random(seed);
                    var color = String.Format("#{0:X6}", random.Next(0x1000000));
                for (int i = 0; i < elist.Count; i++)
                    {
                            ePlan.Add(new
                            {
                                id = elist[i].name,
                                start = elist[i].start,
                                end = elist[i].end,
                                stroke = "#B8AA96",
                                fill = new
                                {
                                    angle = 90,
                                    keys = new[] {
                                    new { color = color, position = 0 }
                                }
                                }
                            });

                    };
                    eqpPlan.Add(new
                    {
                        id = item.name,
                        name = item.name,
                        periods = ePlan
                    });

                seed += 1;
            }
            ViewBag.Data = eqpPlan;

            return PartialView();
        }

        public ActionResult SelectCategory()
        {

            List<SelectListItem> step = new List<SelectListItem>();

            step.Add(new SelectListItem { Text = "Select", Value = "",Selected = true });

            step.Add(new SelectListItem { Text = "PRESS", Value = "PRESS" });

            step.Add(new SelectListItem { Text = "PAINT", Value = "PAINT",  });

            step.Add(new SelectListItem { Text = "FINISH", Value = "FINISH" });

            List<SelectListItem> product = new List<SelectListItem>();

            product.Add(new SelectListItem { Text = "Select", Value = "", Selected = true });

            product.Add(new SelectListItem { Text = "KANU", Value = "KANU" });

            product.Add(new SelectListItem { Text = "STARBUCKS", Value = "STARBUCKS", });

            product.Add(new SelectListItem { Text = "TOMNTOMS", Value = "TOMNTOMS" });

            ViewBag.EQP = step;

            ViewBag.Product = product;

            return View();

        }

        public ActionResult Search()
        {

            return RedirectToAction("Index");

        }

        //public string ListToJsonObj(List<EqpPlan> list)
        //{
        //    StringBuilder JsonString = new StringBuilder();
        //    if (list != null && list.Count > 0)
        //    {
        //        JsonString.Append("[");
        //        for (int i = 0; i < list.Count; i++)
        //        {
        //            JsonString.Append("{");
        //            for (int j = 0; j < 3; j++)
        //            {
        //                if (j == 0)
        //                {
        //                    JsonString.Append("\"" + "id" + "\":" + "\"" + list[i].LOT_ID + "\",");
        //                }
        //                else if (j == 1)
        //                {
        //                    JsonString.Append("\"" + "start" + "\":" + "\"" + list[i].START_TIME + "\"");
        //                }
        //                else if (j == 2)
        //                {
        //                    JsonString.Append("\"" + "end" + "\":" + "\"" + list[i].END_TIME + "\"");
        //                }
        //            }
        //            if (i == ds.Tables[0].Rows.Count - 1)
        //            {
        //                JsonString.Append("}");
        //            }
        //            else
        //            {
        //                JsonString.Append("},");
        //            }
        //        }
        //        JsonString.Append("]");
        //        return JsonString.ToString();
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

    }
}