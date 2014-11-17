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
using LINQtoCSV;
using System.Data.SqlClient;
using System.Configuration;

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

        class Property
        {
            [CsvColumn(Name = "AGENT_REF", CanBeNull = false, FieldIndex = 1)]
            public string AGENT_REF { get; set; }

            [CsvColumn(Name = "ADDRESS_1", FieldIndex = 2)]
            public string ADDRESS_1 { get; set; }
            [CsvColumn(Name = "ADDRESS_2", FieldIndex = 3)]
            public string ADDRESS_2 { get; set; }
            [CsvColumn(Name = "ADDRESS_3", FieldIndex = 4)]
            public string ADDRESS_3 { get; set; }
            [CsvColumn(Name = "TOWN", FieldIndex = 5)]
            public string TOWN { get; set; }
            [CsvColumn(Name = "POSTCODE1", FieldIndex = 6)]
            public string POSTCODE1 { get; set; }
            [CsvColumn(Name = "POSTCODE2", FieldIndex = 7)]
            public string POSTCODE2 { get; set; }
            [CsvColumn(Name = "FEATURE1", FieldIndex = 8)]
            public string FEATURE1 { get; set; }
            [CsvColumn(Name = "FEATURE2", FieldIndex = 9)]
            public string FEATURE2 { get; set; }
            [CsvColumn(Name = "FEATURE3", FieldIndex = 10)]
            public string FEATURE3 { get; set; }
            [CsvColumn(Name = "FEATURE4", FieldIndex = 11)]
            public string FEATURE4 { get; set; }
            [CsvColumn(Name = "FEATURE5", FieldIndex = 12)]
            public string FEATURE5 { get; set; }
            [CsvColumn(Name = "FEATURE6", FieldIndex = 13)]
            public string FEATURE6 { get; set; }
            [CsvColumn(Name = "FEATURE7", FieldIndex = 14)]
            public string FEATURE7 { get; set; }
            [CsvColumn(Name = "FEATURE8", FieldIndex = 15)]
            public string FEATURE8 { get; set; }
            [CsvColumn(Name = "FEATURE9", FieldIndex = 16)]
            public string FEATURE9 { get; set; }
            [CsvColumn(Name = "FEATURE10", FieldIndex = 17)]
            public string FEATURE10 { get; set; }
            [CsvColumn(Name = "SUMMARY", FieldIndex = 18)]
            public string SUMMARY { get; set; }
            [CsvColumn(Name = "DESCRIPTION", FieldIndex = 19)]
            public string DESCRIPTION { get; set; }
            [CsvColumn(Name = "BRANCH_ID", FieldIndex = 20)]
            public string BRANCH_ID { get; set; }
            [CsvColumn(Name = "STATUS_ID", FieldIndex = 21)]
            public string STATUS_ID { get; set; }
            [CsvColumn(Name = "BEDROOMS", FieldIndex = 22)]
            public string BEDROOMS { get; set; }
            [CsvColumn(Name = "PRICE", FieldIndex = 23)]
            public string PRICE { get; set; }
            [CsvColumn(Name = "PRICE_QUALIFIER", FieldIndex = 24)]
            public string PRICE_QUALIFIER { get; set; }
            [CsvColumn(Name = "PROP_SUB_ID", FieldIndex = 25)]
            public string PROP_SUB_ID { get; set; }
            [CsvColumn(Name = "CREATE_DATE", FieldIndex = 26)]
            public string CREATE_DATE { get; set; }
            [CsvColumn(Name = "UPDATE_DATE", FieldIndex = 27)]
            public string UPDATE_DATE { get; set; }
            [CsvColumn(Name = "DISPLAY_ADDRESS", FieldIndex = 28)]
            public string DISPLAY_ADDRESS { get; set; }
            [CsvColumn(Name = "PUBLISHED_FLAG", FieldIndex = 29)]
            public string PUBLISHED_FLAG { get; set; }
            [CsvColumn(Name = "LET_DATE_AVAILABLE", FieldIndex = 30)]
            public string LET_DATE_AVAILABLE { get; set; }
            [CsvColumn(Name = "LET_BOND", FieldIndex = 31)]
            public string LET_BOND { get; set; }
            [CsvColumn(Name = "LET_TYPE_ID", FieldIndex = 32)]
            public string LET_TYPE_ID { get; set; }
            [CsvColumn(Name = "LET_FURN_ID", FieldIndex = 33)]
            public string LET_FURN_ID { get; set; }
            [CsvColumn(Name = "LET_RENT_FREQUENCY", FieldIndex = 34)]
            public string LET_RENT_FREQUENCY { get; set; }
            [CsvColumn(Name = "TENURE_TYPE_ID", FieldIndex = 35)]
            public string TENURE_TYPE_ID { get; set; }
            [CsvColumn(Name = "TRANS_TYPE_ID", FieldIndex = 36)]
            public string TRANS_TYPE_ID { get; set; }
            [CsvColumn(Name = "NEW_HOME_FLAG", FieldIndex = 37)]
            public string NEW_HOME_FLAG { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_00", FieldIndex = 38)]
            public string MEDIA_IMAGE_00 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_TEXT_00", FieldIndex = 39)]
            public string MEDIA_IMAGE_TEXT_00 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_01", FieldIndex = 40)]
            public string MEDIA_IMAGE_01 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_TEXT_01", FieldIndex = 41)]
            public string MEDIA_IMAGE_TEXT_01 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_02", FieldIndex = 42)]
            public string MEDIA_IMAGE_02 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_TEXT_02", FieldIndex = 43)]
            public string MEDIA_IMAGE_TEXT_02 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_03", FieldIndex = 44)]
            public string MEDIA_IMAGE_03 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_TEXT_03", FieldIndex = 45)]
            public string MEDIA_IMAGE_TEXT_03 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_04", FieldIndex = 46)]
            public string MEDIA_IMAGE_04 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_TEXT_04", FieldIndex = 47)]
            public string MEDIA_IMAGE_TEXT_04 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_05", FieldIndex = 48)]
            public string MEDIA_IMAGE_05 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_TEXT_05", FieldIndex = 49)]
            public string MEDIA_IMAGE_TEXT_05 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_06", FieldIndex = 50)]
            public string MEDIA_IMAGE_06 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_TEXT_06", FieldIndex = 51)]
            public string MEDIA_IMAGE_TEXT_06 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_07", FieldIndex = 52)]
            public string MEDIA_IMAGE_07 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_TEXT_07", FieldIndex = 53)]
            public string MEDIA_IMAGE_TEXT_07 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_08", FieldIndex = 54)]
            public string MEDIA_IMAGE_08 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_TEXT_08", FieldIndex = 55)]
            public string MEDIA_IMAGE_TEXT_08 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_09", FieldIndex = 56)]
            public string MEDIA_IMAGE_09 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_TEXT_09", FieldIndex = 57)]
            public string MEDIA_IMAGE_TEXT_09 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_10", FieldIndex = 58)]
            public string MEDIA_IMAGE_10 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_TEXT_10", FieldIndex = 59)]
            public string MEDIA_IMAGE_TEXT_10 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_11", FieldIndex = 60)]
            public string MEDIA_IMAGE_11 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_TEXT_11", FieldIndex = 61)]
            public string MEDIA_IMAGE_TEXT_11 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_12", FieldIndex = 62)]
            public string MEDIA_IMAGE_12 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_TEXT_12", FieldIndex = 63)]
            public string MEDIA_IMAGE_TEXT_12 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_13", FieldIndex = 64)]
            public string MEDIA_IMAGE_13 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_TEXT_13", FieldIndex = 65)]
            public string MEDIA_IMAGE_TEXT_13 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_14", FieldIndex = 66)]
            public string MEDIA_IMAGE_14 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_TEXT_14", FieldIndex = 67)]
            public string MEDIA_IMAGE_TEXT_14 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_15", FieldIndex = 68)]
            public string MEDIA_IMAGE_15 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_TEXT_15", FieldIndex = 69)]
            public string MEDIA_IMAGE_TEXT_15 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_16", FieldIndex = 70)]
            public string MEDIA_IMAGE_16 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_TEXT_16", FieldIndex = 71)]
            public string MEDIA_IMAGE_TEXT_16 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_17", FieldIndex = 72)]
            public string MEDIA_IMAGE_17 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_TEXT_17", FieldIndex = 73)]
            public string MEDIA_IMAGE_TEXT_17 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_18", FieldIndex = 74)]
            public string MEDIA_IMAGE_18 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_TEXT_18", FieldIndex = 75)]
            public string MEDIA_IMAGE_TEXT_18 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_19", FieldIndex = 76)]
            public string MEDIA_IMAGE_19 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_TEXT_19", FieldIndex = 77)]
            public string MEDIA_IMAGE_TEXT_19 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_20", FieldIndex = 78)]
            public string MEDIA_IMAGE_20 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_TEXT_20", FieldIndex = 79)]
            public string MEDIA_IMAGE_TEXT_20 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_21", FieldIndex = 80)]
            public string MEDIA_IMAGE_21 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_TEXT_21", FieldIndex = 81)]
            public string MEDIA_IMAGE_TEXT_21 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_22", FieldIndex = 82)]
            public string MEDIA_IMAGE_22 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_TEXT_22", FieldIndex = 83)]
            public string MEDIA_IMAGE_TEXT_22 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_23", FieldIndex = 84)]
            public string MEDIA_IMAGE_23 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_TEXT_23", FieldIndex = 85)]
            public string MEDIA_IMAGE_TEXT_23 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_24", FieldIndex = 86)]
            public string MEDIA_IMAGE_24 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_TEXT_24", FieldIndex = 87)]
            public string MEDIA_IMAGE_TEXT_24 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_25", FieldIndex = 88)]
            public string MEDIA_IMAGE_25 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_TEXT_25", FieldIndex = 89)]
            public string MEDIA_IMAGE_TEXT_25 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_26", FieldIndex = 90)]
            public string MEDIA_IMAGE_26 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_TEXT_26", FieldIndex = 91)]
            public string MEDIA_IMAGE_TEXT_26 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_27", FieldIndex = 92)]
            public string MEDIA_IMAGE_27 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_TEXT_27", FieldIndex = 93)]
            public string MEDIA_IMAGE_TEXT_27 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_28", FieldIndex = 94)]
            public string MEDIA_IMAGE_28 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_TEXT_28", FieldIndex = 95)]
            public string MEDIA_IMAGE_TEXT_28 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_29", FieldIndex = 96)]
            public string MEDIA_IMAGE_29 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_TEXT_29", FieldIndex = 97)]
            public string MEDIA_IMAGE_TEXT_29 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_30", FieldIndex = 98)]
            public string MEDIA_IMAGE_30 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_TEXT_30", FieldIndex = 99)]
            public string MEDIA_IMAGE_TEXT_30 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_31", FieldIndex = 100)]
            public string MEDIA_IMAGE_31 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_TEXT_31", FieldIndex = 101)]
            public string MEDIA_IMAGE_TEXT_31 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_32", FieldIndex = 102)]
            public string MEDIA_IMAGE_32 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_TEXT_32", FieldIndex = 103)]
            public string MEDIA_IMAGE_TEXT_32 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_33", FieldIndex = 104)]
            public string MEDIA_IMAGE_33 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_TEXT_33", FieldIndex = 105)]
            public string MEDIA_IMAGE_TEXT_33 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_34", FieldIndex = 106)]
            public string MEDIA_IMAGE_34 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_TEXT_34", FieldIndex = 107)]
            public string MEDIA_IMAGE_TEXT_34 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_60", FieldIndex = 108)]
            public string MEDIA_IMAGE_60 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_TEXT_60", FieldIndex = 109)]
            public string MEDIA_IMAGE_TEXT_60 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_61", FieldIndex = 110)]
            public string MEDIA_IMAGE_61 { get; set; }
            [CsvColumn(Name = "MEDIA_IMAGE_TEXT_61", FieldIndex = 111)]
            public string MEDIA_IMAGE_TEXT_61 { get; set; }
            [CsvColumn(Name = "MEDIA_FLOOR_PLAN_00", FieldIndex = 112)]
            public string MEDIA_FLOOR_PLAN_00 { get; set; }
            [CsvColumn(Name = "MEDIA_FLOOR_PLAN_TEXT_00", FieldIndex = 113)]
            public string MEDIA_FLOOR_PLAN_TEXT_00 { get; set; }
            [CsvColumn(Name = "MEDIA_FLOOR_PLAN_01", FieldIndex = 114)]
            public string MEDIA_FLOOR_PLAN_01 { get; set; }
            [CsvColumn(Name = "MEDIA_FLOOR_PLAN_TEXT_01", FieldIndex = 115)]
            public string MEDIA_FLOOR_PLAN_TEXT_01 { get; set; }
            [CsvColumn(Name = "MEDIA_FLOOR_PLAN_02", FieldIndex = 116)]
            public string MEDIA_FLOOR_PLAN_02 { get; set; }
            [CsvColumn(Name = "MEDIA_FLOOR_PLAN_TEXT_02", FieldIndex = 117)]
            public string MEDIA_FLOOR_PLAN_TEXT_02 { get; set; }
            [CsvColumn(Name = "MEDIA_FLOOR_PLAN_03", FieldIndex = 118)]
            public string MEDIA_FLOOR_PLAN_03 { get; set; }
            [CsvColumn(Name = "MEDIA_FLOOR_PLAN_TEXT_03", FieldIndex = 119)]
            public string MEDIA_FLOOR_PLAN_TEXT_03 { get; set; }
            [CsvColumn(Name = "MEDIA_DOCUMENT_00", FieldIndex = 120)]
            public string MEDIA_DOCUMENT_00 { get; set; }
            [CsvColumn(Name = "MEDIA_DOCUMENT_TEXT_00", FieldIndex = 121)]
            public string MEDIA_DOCUMENT_TEXT_00 { get; set; }
            [CsvColumn(Name = "MEDIA_DOCUMENT_50", FieldIndex = 122)]
            public string MEDIA_DOCUMENT_50 { get; set; }
            [CsvColumn(Name = "MEDIA_DOCUMENT_TEXT_50", FieldIndex = 123)]
            public string MEDIA_DOCUMENT_TEXT_50 { get; set; }
            [CsvColumn(Name = "MEDIA_DOCUMENT_51", FieldIndex = 124)]
            public string MEDIA_DOCUMENT_51 { get; set; }
            [CsvColumn(Name = "MEDIA_DOCUMENT_TEXT_51", FieldIndex = 125)]
            public string MEDIA_DOCUMENT_TEXT_51 { get; set; }
            [CsvColumn(Name = "MEDIA_VIRTUAL_TOUR_00", FieldIndex = 126)]
            public string MEDIA_VIRTUAL_TOUR_00 { get; set; }
            [CsvColumn(Name = "MEDIA_VIRTUAL_TOUR_TEXT_00", FieldIndex = 127)]
            public string MEDIA_VIRTUAL_TOUR_TEXT_00 { get; set; }

        }
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
                    //newFile.WriteLine(line);
                    newFile.Close();

                    // lblPropertyOutput.Text = line;

                }

                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[127] {
                    new DataColumn("AGENT_REF", typeof(string)),
                new DataColumn("ADDRESS_1", typeof(string)),
new DataColumn("ADDRESS_2", typeof(string)),
new DataColumn("ADDRESS_3", typeof(string)),
new DataColumn("TOWN", typeof(string)),
new DataColumn("POSTCODE1", typeof(string)),
new DataColumn("POSTCODE2", typeof(string)),
new DataColumn("FEATURE1", typeof(string)),
new DataColumn("FEATURE2", typeof(string)),
new DataColumn("FEATURE3", typeof(string)),
new DataColumn("FEATURE4", typeof(string)),
new DataColumn("FEATURE5", typeof(string)),
new DataColumn("FEATURE6", typeof(string)),
new DataColumn("FEATURE7", typeof(string)),
new DataColumn("FEATURE8", typeof(string)),
new DataColumn("FEATURE9", typeof(string)),
new DataColumn("FEATURE10", typeof(string)),
new DataColumn("SUMMARY", typeof(string)),
new DataColumn("DESCRIPTION", typeof(string)),
new DataColumn("BRANCH_ID", typeof(string)),
new DataColumn("STATUS_ID", typeof(string)),
new DataColumn("BEDROOMS", typeof(string)),
new DataColumn("PRICE", typeof(string)),
new DataColumn("PRICE_QUALIFIER", typeof(string)),
new DataColumn("PROP_SUB_ID", typeof(string)),
new DataColumn("CREATE_DATE", typeof(string)),
new DataColumn("UPDATE_DATE", typeof(string)),
new DataColumn("DISPLAY_ADDRESS", typeof(string)),
new DataColumn("PUBLISHED_FLAG", typeof(string)),
new DataColumn("LET_DATE_AVAILABLE", typeof(string)),
new DataColumn("LET_BOND", typeof(string)),
new DataColumn("LET_TYPE_ID", typeof(string)),
new DataColumn("LET_FURN_ID", typeof(string)),
new DataColumn("LET_RENT_FREQUENCY", typeof(string)),
new DataColumn("TENURE_TYPE_ID", typeof(string)),
new DataColumn("TRANS_TYPE_ID", typeof(string)),
new DataColumn("NEW_HOME_FLAG", typeof(string)),
new DataColumn("MEDIA_IMAGE_00", typeof(string)),
new DataColumn("MEDIA_IMAGE_TEXT_00", typeof(string)),
new DataColumn("MEDIA_IMAGE_01", typeof(string)),
new DataColumn("MEDIA_IMAGE_TEXT_01", typeof(string)),
new DataColumn("MEDIA_IMAGE_02", typeof(string)),
new DataColumn("MEDIA_IMAGE_TEXT_02", typeof(string)),
new DataColumn("MEDIA_IMAGE_03", typeof(string)),
new DataColumn("MEDIA_IMAGE_TEXT_03", typeof(string)),
new DataColumn("MEDIA_IMAGE_04", typeof(string)),
new DataColumn("MEDIA_IMAGE_TEXT_04", typeof(string)),
new DataColumn("MEDIA_IMAGE_05", typeof(string)),
new DataColumn("MEDIA_IMAGE_TEXT_05", typeof(string)),
new DataColumn("MEDIA_IMAGE_06", typeof(string)),
new DataColumn("MEDIA_IMAGE_TEXT_06", typeof(string)),
new DataColumn("MEDIA_IMAGE_07", typeof(string)),
new DataColumn("MEDIA_IMAGE_TEXT_07", typeof(string)),
new DataColumn("MEDIA_IMAGE_08", typeof(string)),
new DataColumn("MEDIA_IMAGE_TEXT_08", typeof(string)),
new DataColumn("MEDIA_IMAGE_09", typeof(string)),
new DataColumn("MEDIA_IMAGE_TEXT_09", typeof(string)),
new DataColumn("MEDIA_IMAGE_10", typeof(string)),
new DataColumn("MEDIA_IMAGE_TEXT_10", typeof(string)),
new DataColumn("MEDIA_IMAGE_11", typeof(string)),
new DataColumn("MEDIA_IMAGE_TEXT_11", typeof(string)),
new DataColumn("MEDIA_IMAGE_12", typeof(string)),
new DataColumn("MEDIA_IMAGE_TEXT_12", typeof(string)),
new DataColumn("MEDIA_IMAGE_13", typeof(string)),
new DataColumn("MEDIA_IMAGE_TEXT_13", typeof(string)),
new DataColumn("MEDIA_IMAGE_14", typeof(string)),
new DataColumn("MEDIA_IMAGE_TEXT_14", typeof(string)),
new DataColumn("MEDIA_IMAGE_15", typeof(string)),
new DataColumn("MEDIA_IMAGE_TEXT_15", typeof(string)),
new DataColumn("MEDIA_IMAGE_16", typeof(string)),
new DataColumn("MEDIA_IMAGE_TEXT_16", typeof(string)),
new DataColumn("MEDIA_IMAGE_17", typeof(string)),
new DataColumn("MEDIA_IMAGE_TEXT_17", typeof(string)),
new DataColumn("MEDIA_IMAGE_18", typeof(string)),
new DataColumn("MEDIA_IMAGE_TEXT_18", typeof(string)),
new DataColumn("MEDIA_IMAGE_19", typeof(string)),
new DataColumn("MEDIA_IMAGE_TEXT_19", typeof(string)),
new DataColumn("MEDIA_IMAGE_20", typeof(string)),
new DataColumn("MEDIA_IMAGE_TEXT_20", typeof(string)),
new DataColumn("MEDIA_IMAGE_21", typeof(string)),
new DataColumn("MEDIA_IMAGE_TEXT_21", typeof(string)),
new DataColumn("MEDIA_IMAGE_22", typeof(string)),
new DataColumn("MEDIA_IMAGE_TEXT_22", typeof(string)),
new DataColumn("MEDIA_IMAGE_23", typeof(string)),
new DataColumn("MEDIA_IMAGE_TEXT_23", typeof(string)),
new DataColumn("MEDIA_IMAGE_24", typeof(string)),
new DataColumn("MEDIA_IMAGE_TEXT_24", typeof(string)),
new DataColumn("MEDIA_IMAGE_25", typeof(string)),
new DataColumn("MEDIA_IMAGE_TEXT_25", typeof(string)),
new DataColumn("MEDIA_IMAGE_26", typeof(string)),
new DataColumn("MEDIA_IMAGE_TEXT_26", typeof(string)),
new DataColumn("MEDIA_IMAGE_27", typeof(string)),
new DataColumn("MEDIA_IMAGE_TEXT_27", typeof(string)),
new DataColumn("MEDIA_IMAGE_28", typeof(string)),
new DataColumn("MEDIA_IMAGE_TEXT_28", typeof(string)),
new DataColumn("MEDIA_IMAGE_29", typeof(string)),
new DataColumn("MEDIA_IMAGE_TEXT_29", typeof(string)),
new DataColumn("MEDIA_IMAGE_30", typeof(string)),
new DataColumn("MEDIA_IMAGE_TEXT_30", typeof(string)),
new DataColumn("MEDIA_IMAGE_31", typeof(string)),
new DataColumn("MEDIA_IMAGE_TEXT_31", typeof(string)),
new DataColumn("MEDIA_IMAGE_32", typeof(string)),
new DataColumn("MEDIA_IMAGE_TEXT_32", typeof(string)),
new DataColumn("MEDIA_IMAGE_33", typeof(string)),
new DataColumn("MEDIA_IMAGE_TEXT_33", typeof(string)),
new DataColumn("MEDIA_IMAGE_34", typeof(string)),
new DataColumn("MEDIA_IMAGE_TEXT_34", typeof(string)),
new DataColumn("MEDIA_IMAGE_60", typeof(string)),
new DataColumn("MEDIA_IMAGE_TEXT_60", typeof(string)),
new DataColumn("MEDIA_IMAGE_61", typeof(string)),
new DataColumn("MEDIA_IMAGE_TEXT_61", typeof(string)),
new DataColumn("MEDIA_FLOOR_PLAN_00", typeof(string)),
new DataColumn("MEDIA_FLOOR_PLAN_TEXT_00", typeof(string)),
new DataColumn("MEDIA_FLOOR_PLAN_01", typeof(string)),
new DataColumn("MEDIA_FLOOR_PLAN_TEXT_01", typeof(string)),
new DataColumn("MEDIA_FLOOR_PLAN_02", typeof(string)),
new DataColumn("MEDIA_FLOOR_PLAN_TEXT_02", typeof(string)),
new DataColumn("MEDIA_FLOOR_PLAN_03", typeof(string)),
new DataColumn("MEDIA_FLOOR_PLAN_TEXT_03", typeof(string)),
new DataColumn("MEDIA_DOCUMENT_00", typeof(string)),
new DataColumn("MEDIA_DOCUMENT_TEXT_00", typeof(string)),
new DataColumn("MEDIA_DOCUMENT_50", typeof(string)),
new DataColumn("MEDIA_DOCUMENT_TEXT_50", typeof(string)),
new DataColumn("MEDIA_DOCUMENT_51", typeof(string)),
new DataColumn("MEDIA_DOCUMENT_TEXT_51", typeof(string)),
new DataColumn("MEDIA_VIRTUAL_TOUR_00", typeof(string)),
new DataColumn("MEDIA_VIRTUAL_TOUR_TEXT_00", typeof(string))
            });

                string csvData = File.ReadAllText(Server.MapPath(ControlPath + "/PropertyFiles/newfile.csv"));

                foreach (string row in csvData.Split('~'))
                {
                    if (!string.IsNullOrEmpty(row))
                    {
                        dt.Rows.Add();
                        int i = 0;
                        foreach (string cell in row.Split('^'))
                        {
                            dt.Rows[dt.Rows.Count - 1][i] = cell;
                            i++;
                            //dt.Rows.Add(cell);
                        }
                    }
                }

                //this.PropertyGrid.Visible = true;
                //PropertyGrid.DataSource = dt;
                //PropertyGrid.DataBind();



                var connectionString = DotNetNuke.Common.Utilities.Config.GetConnectionString("SiteSqlServer");

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                    {

                        try
                        {
                            //Set the database table name
                            sqlBulkCopy.DestinationTableName = "dbo.RightmovePropertiesProperties";
                            con.Open();
                            sqlBulkCopy.WriteToServer(dt);
                            con.Close();
                        }
                        catch (Exception exc) //Module failed to load
                        {
                            Exceptions.ProcessModuleLoadException(this, exc);
                        }
                    }
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