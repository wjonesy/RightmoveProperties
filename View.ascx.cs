/*
' Copyright (c) 2014  Christoc.com
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/

using System;
using System.Web.UI.WebControls;
using Christoc.Modules.RightmoveProperties.Components;
using DotNetNuke.Security;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Services.Localization;
using DotNetNuke.UI.Utilities;
using System.IO;
using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;
using System.Data;
using System.Text;
using LumenWorks.Framework.IO.Csv;

namespace Christoc.Modules.RightmoveProperties
{
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The View class displays the content
    /// 
    /// Typically your view control would be used to display content or functionality in your module.
    /// 
    /// View may be the only control you have in your project depending on the complexity of your module
    /// 
    /// Because the control inherits from RightmovePropertiesModuleBase you have access to any custom properties
    /// defined there, as well as properties from DNN such as PortalId, ModuleId, TabId, UserId and many more.
    /// 
    /// </summary>
    /// -----------------------------------------------------------------------------
    public partial class View : RightmovePropertiesModuleBase, IActionable
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
               
              

                List<string> recordList = new List<string>();

                string path = Server.MapPath(ControlPath + "/PropertyFiles/WardH2014110401.BLM");

                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    StreamReader file = new StreamReader(fs);
                    string line = file.ReadToEnd();
                    file.Close();

                    line = line.Replace(System.Environment.NewLine, "");
                    line = line.Replace("#HEADER#Version : 3EOF : '^'EOR : '~'Property Count : 14Generated Date : 04-NOV-2014 14:05#DEFINITION#", "");
                    line = line.Replace("#DATA#", "");
                    line = line.Replace("#END#", "");


                    StreamWriter newFile = new StreamWriter(Server.MapPath(ControlPath + "/PropertyFiles/newfile.csv"));
                    newFile.WriteLine(line);
                    newFile.Close();

                    lblPropertyOutput.Text = line;

                    //using (CsvReader csvReader = new CsvReader(new StreamReader(Server.MapPath(ControlPath + "/PropertyFiles/newfile.csv")), true, '^'))
                    //{

                    //    int fieldCount = csvReader.FieldCount;

                    //    //string[] headers = csvReader.GetFieldHeaders();
                    //    //while (csvReader.ReadNextRecord())
                    //    //{
                    //    //    for (int i = 0; i < fieldCount; i++)
                    //    //        Console.Write(string.Format("{0} = {1};",
                    //    //                      headers[i], csvReader[i]));
                    //    //    Console.WriteLine();
                    //    //}

                    //    lblPropertyOutput.Text = fieldCount.ToString();

                       
                    //}
                }
            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }






        public ModuleActionCollection ModuleActions
        {
            get
            {
                var actions = new ModuleActionCollection
                    {
                        {
                            GetNextActionID(), Localization.GetString("EditModule", LocalResourceFile), "", "", "",
                            EditUrl(), false, SecurityAccessLevel.Edit, true, false
                        }
                    };
                return actions;
            }
        }





        protected void btnSyncProperties_Click(object sender, EventArgs e)
        {


            try
            {



                //string line = sr.ReadLine();
                //string[] value = line.Split('^');




                //lblPropertyOutput.Text = sr.ReadToEnd().ToString();



            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }

        }
    }
}