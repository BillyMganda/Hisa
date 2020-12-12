using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hisa
{
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
        }
        //when reports window is loaded
        private void Reports_Load(object sender, EventArgs e)
        {

        }
        //when treeview is expanded
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //Daily Issue Summary
            if(treeView1.SelectedNode.Text == "Daily Issue Summary")
            {
                MainPanel.Controls.Clear();
                MainPanel.Visible = true;
                DailyIssueSummaryControl disc = new DailyIssueSummaryControl();
                disc.Show();
                MainPanel.Controls.Add(disc);
            }
            //Consumption per department
            if(treeView1.SelectedNode.Text == "Consumption per Department")
            {
                MainPanel.Controls.Clear();
                MainPanel.Visible = true;
                ConsumptionDepartmentControl con = new ConsumptionDepartmentControl();
                con.Show();
                MainPanel.Controls.Add(con);
            }
            //Department Consumption/ Main Group
            if (treeView1.SelectedNode.Text == "Department Consumption/Main Group")
            {
                MainPanel.Controls.Clear();
                MainPanel.Visible = true;
                DepartmentConsMain dep = new DepartmentConsMain();
                dep.Show();
                MainPanel.Controls.Add(dep);
            }
            //Department Consumption/ Sub group
            if (treeView1.SelectedNode.Text == "Department Consumption/Sub group")
            {
                MainPanel.Controls.Clear();
                MainPanel.Visible = true;
                DepartmentConsSub dept = new DepartmentConsSub();
                dept.Show();
                MainPanel.Controls.Add(dept);
            }
            //Department Consumption/Item
            if (treeView1.SelectedNode.Text == "Department Consumption/Item")
            {
                MainPanel.Controls.Clear();
                MainPanel.Visible = true;
                DepartmentConsItem de = new DepartmentConsItem();
                de.Show();
                MainPanel.Controls.Add(de);
            }
            //Overall consumption
            if (treeView1.SelectedNode.Text == "Overall Consumption")
            {
                MainPanel.Controls.Clear();
                MainPanel.Visible = true;
                OverallConsumptionControl ov = new OverallConsumptionControl();
                ov.Show();
                MainPanel.Controls.Add(ov);
            }
            //Stocksheet
            if (treeView1.SelectedNode.Text == "Stocksheet")                            
            {
                MainPanel.Controls.Clear();
                MainPanel.Visible = true;
                StocksheetControl sc = new StocksheetControl();
                sc.Show();
                MainPanel.Controls.Add(sc);
            }
            //Opening Stock
            if (treeView1.SelectedNode.Text == "Opening Stock")
            {
                MainPanel.Controls.Clear();
                MainPanel.Visible = true;
                OpeningStockControl osc = new OpeningStockControl();
                osc.Show();
                MainPanel.Controls.Add(osc);
            }
            //Closing Stock
            if (treeView1.SelectedNode.Text == "Closing Stock")
            {
                MainPanel.Controls.Clear();
                MainPanel.Visible = true;
                ClosingStockControl csc = new ClosingStockControl();
                csc.Show();
                MainPanel.Controls.Add(csc);
            }
            //Stock on Hand
            if (treeView1.SelectedNode.Text == "Stock on Hand")
            {
                MainPanel.Controls.Clear();
                MainPanel.Visible = true;
                StockOnHandControl soh = new StockOnHandControl();
                soh.Show();
                MainPanel.Controls.Add(soh);
            }
            //Stock Variance
            if (treeView1.SelectedNode.Text == "Stock Variance")            
            {
                MainPanel.Controls.Clear();
                MainPanel.Visible = true;
                StockVariance sv = new StockVariance();
                sv.Show();
                MainPanel.Controls.Add(sv);
            }
            //Physical Stocks
            if (treeView1.SelectedNode.Text == "Physical Stocks")
            {
                MainPanel.Controls.Clear();
                MainPanel.Visible = true;
                PhysicalStocksControl psc = new PhysicalStocksControl();
                psc.Show();
                MainPanel.Controls.Add(psc);
            }
            //Item History
            if (treeView1.SelectedNode.Text == "Item History")
            {
                MainPanel.Controls.Clear();
                MainPanel.Visible = true;
                ItemHistoryControl ihs = new ItemHistoryControl();
                ihs.Show();
                MainPanel.Controls.Add(ihs);
            }
            
            //Return in List
            if (treeView1.SelectedNode.Text == "Return In List")
            {
                MainPanel.Controls.Clear();
                MainPanel.Visible = true;
                ReturnInList ril = new ReturnInList();
                ril.Show();
                MainPanel.Controls.Add(ril);
            }
            // Return out List
            if (treeView1.SelectedNode.Text == "Return Out List")
            {
                MainPanel.Controls.Clear();
                MainPanel.Visible = true;
                ReturnOutList rol = new ReturnOutList();
                rol.Show();
                MainPanel.Controls.Add(rol);
            }
            // Book Over List
            if (treeView1.SelectedNode.Text == "Book Over List")
            {
                MainPanel.Controls.Clear();
                MainPanel.Visible = true;
                BookOverList bol = new BookOverList();
                bol.Show();
                MainPanel.Controls.Add(bol);
            }
            // Book Short List
            if (treeView1.SelectedNode.Text == "Book Short List")
            {
                MainPanel.Controls.Clear();
                MainPanel.Visible = true;
                BookShortList bsl = new BookShortList();
                bsl.Show();
                MainPanel.Controls.Add(bsl);
            }
            // Item Disposal List
            if (treeView1.SelectedNode.Text == "Item Disposal List")
            {
                MainPanel.Controls.Clear();
                MainPanel.Visible = true;
                ItemDisposalList idl = new ItemDisposalList();
                idl.Show();
                MainPanel.Controls.Add(idl);
            }
            
            // Daily LPO Summary
            if (treeView1.SelectedNode.Text == "Daily LPO Summary")
            {
                MainPanel.Controls.Clear();
                MainPanel.Visible = true;
                DailyLPOSummary dlpo = new DailyLPOSummary();
                dlpo.Show();
                MainPanel.Controls.Add(dlpo);
            }
            // Daily GRN Summary
            if (treeView1.SelectedNode.Text == "Daily GRN Summary")
            {
                MainPanel.Controls.Clear();
                MainPanel.Visible = true;
                DailyGRNSummary dgrn = new DailyGRNSummary();
                dgrn.Show();
                MainPanel.Controls.Add(dgrn);
            }
            // Total Purchases
            if (treeView1.SelectedNode.Text == "Total Purchases")
            {
                MainPanel.Controls.Clear();
                MainPanel.Visible = true;
                TotalPurchases tp = new TotalPurchases();
                tp.Show();
                MainPanel.Controls.Add(tp);
            }
            // Purchases for Specified Main Group
            if (treeView1.SelectedNode.Text == "Purchases for Specified Main Group")
            {
                MainPanel.Controls.Clear();
                MainPanel.Visible = true;
                PurchaseMainGroup pmg = new PurchaseMainGroup();
                pmg.Show();
                MainPanel.Controls.Add(pmg);
            }
            // Purchases for Specified Sub Group
            if (treeView1.SelectedNode.Text == "Purchases for Specifed Sub Group")
            {
                MainPanel.Controls.Clear();
                MainPanel.Visible = true;
                PurchaseSubGroup psg = new PurchaseSubGroup();
                psg.Show();
                MainPanel.Controls.Add(psg);
            }
            // Purchases by sypplier
            if (treeView1.SelectedNode.Text == "Purchases by Supplier")
            {
                MainPanel.Controls.Clear();
                MainPanel.Visible = true;
                PurchaseBySupplier psg = new PurchaseBySupplier();
                psg.Show();
                MainPanel.Controls.Add(psg);
            }
            // Item Purchase History
            if (treeView1.SelectedNode.Text == "Item Purchase History")
            {
                MainPanel.Controls.Clear();
                MainPanel.Visible = true;
                Item_Purchase_History iph = new Item_Purchase_History();
                iph.Show();
                MainPanel.Controls.Add(iph);
            }
            // Open LPOs
            if (treeView1.SelectedNode.Text == "Open LPOs")
            {
                MainPanel.Controls.Clear();
                MainPanel.Visible = true;
                OpenLPOs olpo = new OpenLPOs();
                olpo.Show();
                MainPanel.Controls.Add(olpo);
            }
            // Void LPOs
            if (treeView1.SelectedNode.Text == "Void LPOs")
            {
                MainPanel.Controls.Clear();
                MainPanel.Visible = true;
                VoidLPOs vlpo = new VoidLPOs();
                vlpo.Show();
                MainPanel.Controls.Add(vlpo);
            }
            
            // Supplier List
            if (treeView1.SelectedNode.Text == "Supplier List")
            {
                MainPanel.Controls.Clear();
                MainPanel.Visible = true;
                SupplierList sl = new SupplierList();
                sl.Show();
                MainPanel.Controls.Add(sl);
            }
            //REPRINT LPO
            if (treeView1.SelectedNode.Text == "Reprint LPO")
            {
                MainPanel.Controls.Clear();
                MainPanel.Visible = true;
                Reprint_LPO sl = new Reprint_LPO();
                sl.Show();
                MainPanel.Controls.Add(sl);
            }
            //REPRINT LPO
            if (treeView1.SelectedNode.Text == "Reprint GRN")
            {
                MainPanel.Controls.Clear();
                MainPanel.Visible = true;
                GRN_Reprint sl = new GRN_Reprint();
                sl.Show();
                MainPanel.Controls.Add(sl);
            }
            //REPRINT RETURN TO SUPPLIER
            if (treeView1.SelectedNode.Text == "Reprint Return to Supplier")
            {
                MainPanel.Controls.Clear();
                MainPanel.Visible = true;
                ReprintReturnToSupplier sl = new ReprintReturnToSupplier();
                sl.Show();
                MainPanel.Controls.Add(sl);
            }
            //REPRINT ITEM DISPOSAL
            if (treeView1.SelectedNode.Text == "Reprint Item Disposal")
            {
                MainPanel.Controls.Clear();
                MainPanel.Visible = true;
                ReprintItemDisposal sl = new ReprintItemDisposal();
                sl.Show();
                MainPanel.Controls.Add(sl);
            }
            //REPRINT ISSUE NOTE
            if (treeView1.SelectedNode.Text == "Reprint Issue Note")
            {
                MainPanel.Controls.Clear();
                MainPanel.Visible = true;
                Reprint_Issue_Note sl = new Reprint_Issue_Note();
                sl.Show();
                MainPanel.Controls.Add(sl);
            }
        }
    }
}
