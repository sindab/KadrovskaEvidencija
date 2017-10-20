namespace Kadrovska_sluzba
{
    partial class ucNotifikacije
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraScheduler.TimeRuler timeRuler1 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler2 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler3 = new DevExpress.XtraScheduler.TimeRuler();
            this.dateNavigator = new DevExpress.XtraScheduler.DateNavigator();
            this.schedulerControl1 = new DevExpress.XtraScheduler.SchedulerControl();
            this.schedulerStorage1 = new DevExpress.XtraScheduler.SchedulerStorage(this.components);
            this.appointmentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kadrovskaDataSet = new Kadrovska_sluzba.KadrovskaDataSet();
            this.resourcesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.appointmentsTableAdapter = new Kadrovska_sluzba.KadrovskaDataSetTableAdapters.AppointmentsTableAdapter();
            this.resourcesTableAdapter = new Kadrovska_sluzba.KadrovskaDataSetTableAdapters.ResourcesTableAdapter();
            this.schedulerBarController1 = new DevExpress.XtraScheduler.UI.SchedulerBarController();
            this.switchToDayViewItem1 = new DevExpress.XtraScheduler.UI.SwitchToDayViewItem();
            this.switchToWorkWeekViewItem1 = new DevExpress.XtraScheduler.UI.SwitchToWorkWeekViewItem();
            this.switchToWeekViewItem1 = new DevExpress.XtraScheduler.UI.SwitchToWeekViewItem();
            this.switchToFullWeekViewItem1 = new DevExpress.XtraScheduler.UI.SwitchToFullWeekViewItem();
            this.switchToMonthViewItem1 = new DevExpress.XtraScheduler.UI.SwitchToMonthViewItem();
            this.switchToTimelineViewItem1 = new DevExpress.XtraScheduler.UI.SwitchToTimelineViewItem();
            this.switchToGanttViewItem1 = new DevExpress.XtraScheduler.UI.SwitchToGanttViewItem();
            this.switchToAgendaViewItem1 = new DevExpress.XtraScheduler.UI.SwitchToAgendaViewItem();
            this.switchTimeScalesItem1 = new DevExpress.XtraScheduler.UI.SwitchTimeScalesItem();
            this.changeScaleWidthItem1 = new DevExpress.XtraScheduler.UI.ChangeScaleWidthItem();
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.switchTimeScalesCaptionItem1 = new DevExpress.XtraScheduler.UI.SwitchTimeScalesCaptionItem();
            this.switchCompressWeekendItem1 = new DevExpress.XtraScheduler.UI.SwitchCompressWeekendItem();
            this.switchShowWorkTimeOnlyItem1 = new DevExpress.XtraScheduler.UI.SwitchShowWorkTimeOnlyItem();
            this.switchCellsAutoHeightItem1 = new DevExpress.XtraScheduler.UI.SwitchCellsAutoHeightItem();
            this.changeSnapToCellsUIItem1 = new DevExpress.XtraScheduler.UI.ChangeSnapToCellsUIItem();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kadrovskaDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resourcesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerBarController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // dateNavigator
            // 
            this.dateNavigator.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateNavigator.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Default;
            this.dateNavigator.Cursor = System.Windows.Forms.Cursors.Default;
            this.dateNavigator.Dock = System.Windows.Forms.DockStyle.Right;
            this.dateNavigator.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.dateNavigator.Location = new System.Drawing.Point(682, 141);
            this.dateNavigator.Name = "dateNavigator";
            this.dateNavigator.SchedulerControl = this.schedulerControl1;
            this.dateNavigator.Size = new System.Drawing.Size(225, 510);
            this.dateNavigator.TabIndex = 3;
            // 
            // schedulerControl1
            // 
            this.schedulerControl1.ActiveViewType = DevExpress.XtraScheduler.SchedulerViewType.Month;
            this.schedulerControl1.DataStorage = this.schedulerStorage1;
            this.schedulerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.schedulerControl1.Location = new System.Drawing.Point(0, 141);
            this.schedulerControl1.Name = "schedulerControl1";
            this.schedulerControl1.OptionsView.FirstDayOfWeek = DevExpress.XtraScheduler.FirstDayOfWeek.Monday;
            this.schedulerControl1.Size = new System.Drawing.Size(682, 510);
            this.schedulerControl1.Start = new System.DateTime(2017, 10, 2, 0, 0, 0, 0);
            this.schedulerControl1.TabIndex = 4;
            this.schedulerControl1.Text = "schedulerControl1";
            this.schedulerControl1.Views.DayView.TimeRulers.Add(timeRuler1);
            this.schedulerControl1.Views.FullWeekView.Enabled = true;
            this.schedulerControl1.Views.FullWeekView.TimeRulers.Add(timeRuler2);
            this.schedulerControl1.Views.WorkWeekView.TimeRulers.Add(timeRuler3);
            // 
            // schedulerStorage1
            // 
            this.schedulerStorage1.Appointments.DataSource = this.appointmentsBindingSource;
            this.schedulerStorage1.Appointments.Mappings.AllDay = "AllDay";
            this.schedulerStorage1.Appointments.Mappings.Description = "Description";
            this.schedulerStorage1.Appointments.Mappings.End = "EndDate";
            this.schedulerStorage1.Appointments.Mappings.Label = "Label";
            this.schedulerStorage1.Appointments.Mappings.Location = "Location";
            this.schedulerStorage1.Appointments.Mappings.RecurrenceInfo = "RecurrenceInfo";
            this.schedulerStorage1.Appointments.Mappings.ReminderInfo = "ReminderInfo";
            this.schedulerStorage1.Appointments.Mappings.ResourceId = "ResourceID";
            this.schedulerStorage1.Appointments.Mappings.Start = "StartDate";
            this.schedulerStorage1.Appointments.Mappings.Status = "Status";
            this.schedulerStorage1.Appointments.Mappings.Subject = "Subject";
            this.schedulerStorage1.Appointments.Mappings.TimeZoneId = "TimeZoneId";
            this.schedulerStorage1.Appointments.Mappings.Type = "Type";
            this.schedulerStorage1.Resources.DataSource = this.resourcesBindingSource;
            this.schedulerStorage1.Resources.Mappings.Caption = "ResourceName";
            this.schedulerStorage1.Resources.Mappings.Color = "Color";
            this.schedulerStorage1.Resources.Mappings.Id = "ResourceID";
            this.schedulerStorage1.Resources.Mappings.Image = "Image";
            this.schedulerStorage1.AppointmentsInserted += new DevExpress.XtraScheduler.PersistentObjectsEventHandler(this.schedulerStorage1_AppointmentsChanged);
            this.schedulerStorage1.AppointmentsChanged += new DevExpress.XtraScheduler.PersistentObjectsEventHandler(this.schedulerStorage1_AppointmentsChanged);
            this.schedulerStorage1.AppointmentsDeleted += new DevExpress.XtraScheduler.PersistentObjectsEventHandler(this.schedulerStorage1_AppointmentsChanged);
            // 
            // appointmentsBindingSource
            // 
            this.appointmentsBindingSource.DataMember = "Appointments";
            this.appointmentsBindingSource.DataSource = this.kadrovskaDataSet;
            // 
            // kadrovskaDataSet
            // 
            this.kadrovskaDataSet.DataSetName = "KadrovskaDataSet";
            this.kadrovskaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // resourcesBindingSource
            // 
            this.resourcesBindingSource.DataMember = "Resources";
            this.resourcesBindingSource.DataSource = this.kadrovskaDataSet;
            // 
            // appointmentsTableAdapter
            // 
            this.appointmentsTableAdapter.ClearBeforeFill = true;
            // 
            // resourcesTableAdapter
            // 
            this.resourcesTableAdapter.ClearBeforeFill = true;
            // 
            // schedulerBarController1
            // 
            this.schedulerBarController1.BarItems.Add(this.switchToDayViewItem1);
            this.schedulerBarController1.BarItems.Add(this.switchToWorkWeekViewItem1);
            this.schedulerBarController1.BarItems.Add(this.switchToWeekViewItem1);
            this.schedulerBarController1.BarItems.Add(this.switchToFullWeekViewItem1);
            this.schedulerBarController1.BarItems.Add(this.switchToMonthViewItem1);
            this.schedulerBarController1.BarItems.Add(this.switchToTimelineViewItem1);
            this.schedulerBarController1.BarItems.Add(this.switchToGanttViewItem1);
            this.schedulerBarController1.BarItems.Add(this.switchToAgendaViewItem1);
            this.schedulerBarController1.BarItems.Add(this.switchTimeScalesItem1);
            this.schedulerBarController1.BarItems.Add(this.changeScaleWidthItem1);
            this.schedulerBarController1.BarItems.Add(this.switchTimeScalesCaptionItem1);
            this.schedulerBarController1.BarItems.Add(this.switchCompressWeekendItem1);
            this.schedulerBarController1.BarItems.Add(this.switchShowWorkTimeOnlyItem1);
            this.schedulerBarController1.BarItems.Add(this.switchCellsAutoHeightItem1);
            this.schedulerBarController1.BarItems.Add(this.changeSnapToCellsUIItem1);
            this.schedulerBarController1.Control = this.schedulerControl1;
            // 
            // switchToDayViewItem1
            // 
            this.switchToDayViewItem1.Id = 0;
            this.switchToDayViewItem1.Name = "switchToDayViewItem1";
            // 
            // switchToWorkWeekViewItem1
            // 
            this.switchToWorkWeekViewItem1.Id = 1;
            this.switchToWorkWeekViewItem1.Name = "switchToWorkWeekViewItem1";
            // 
            // switchToWeekViewItem1
            // 
            this.switchToWeekViewItem1.Id = 2;
            this.switchToWeekViewItem1.Name = "switchToWeekViewItem1";
            // 
            // switchToFullWeekViewItem1
            // 
            this.switchToFullWeekViewItem1.Id = 3;
            this.switchToFullWeekViewItem1.Name = "switchToFullWeekViewItem1";
            // 
            // switchToMonthViewItem1
            // 
            this.switchToMonthViewItem1.Id = 4;
            this.switchToMonthViewItem1.Name = "switchToMonthViewItem1";
            // 
            // switchToTimelineViewItem1
            // 
            this.switchToTimelineViewItem1.Id = 5;
            this.switchToTimelineViewItem1.Name = "switchToTimelineViewItem1";
            // 
            // switchToGanttViewItem1
            // 
            this.switchToGanttViewItem1.Id = 6;
            this.switchToGanttViewItem1.Name = "switchToGanttViewItem1";
            // 
            // switchToAgendaViewItem1
            // 
            this.switchToAgendaViewItem1.Id = 7;
            this.switchToAgendaViewItem1.Name = "switchToAgendaViewItem1";
            // 
            // switchTimeScalesItem1
            // 
            this.switchTimeScalesItem1.Id = 8;
            this.switchTimeScalesItem1.Name = "switchTimeScalesItem1";
            // 
            // changeScaleWidthItem1
            // 
            this.changeScaleWidthItem1.Edit = this.repositoryItemSpinEdit1;
            this.changeScaleWidthItem1.Id = 9;
            this.changeScaleWidthItem1.Name = "changeScaleWidthItem1";
            this.changeScaleWidthItem1.UseCommandCaption = true;
            // 
            // repositoryItemSpinEdit1
            // 
            this.repositoryItemSpinEdit1.AutoHeight = false;
            this.repositoryItemSpinEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSpinEdit1.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.repositoryItemSpinEdit1.MaxValue = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.repositoryItemSpinEdit1.MinValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.repositoryItemSpinEdit1.Name = "repositoryItemSpinEdit1";
            // 
            // switchTimeScalesCaptionItem1
            // 
            this.switchTimeScalesCaptionItem1.Id = 10;
            this.switchTimeScalesCaptionItem1.Name = "switchTimeScalesCaptionItem1";
            // 
            // switchCompressWeekendItem1
            // 
            this.switchCompressWeekendItem1.Id = 11;
            this.switchCompressWeekendItem1.Name = "switchCompressWeekendItem1";
            // 
            // switchShowWorkTimeOnlyItem1
            // 
            this.switchShowWorkTimeOnlyItem1.Id = 12;
            this.switchShowWorkTimeOnlyItem1.Name = "switchShowWorkTimeOnlyItem1";
            // 
            // switchCellsAutoHeightItem1
            // 
            this.switchCellsAutoHeightItem1.Id = 13;
            this.switchCellsAutoHeightItem1.Name = "switchCellsAutoHeightItem1";
            // 
            // changeSnapToCellsUIItem1
            // 
            this.changeSnapToCellsUIItem1.Id = 14;
            this.changeSnapToCellsUIItem1.Name = "changeSnapToCellsUIItem1";
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.switchToDayViewItem1,
            this.switchToWorkWeekViewItem1,
            this.switchToWeekViewItem1,
            this.switchToFullWeekViewItem1,
            this.switchToMonthViewItem1,
            this.switchToTimelineViewItem1,
            this.switchToGanttViewItem1,
            this.switchToAgendaViewItem1,
            this.switchTimeScalesItem1,
            this.changeScaleWidthItem1,
            this.switchTimeScalesCaptionItem1,
            this.switchCompressWeekendItem1,
            this.switchShowWorkTimeOnlyItem1,
            this.switchCellsAutoHeightItem1,
            this.changeSnapToCellsUIItem1});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 1;
            this.ribbonControl1.MdiMergeStyle = DevExpress.XtraBars.Ribbon.RibbonMdiMergeStyle.Always;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemSpinEdit1});
            this.ribbonControl1.Size = new System.Drawing.Size(907, 141);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup3});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Kadrovska evidencija";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.switchToDayViewItem1);
            this.ribbonPageGroup1.ItemLinks.Add(this.switchToWorkWeekViewItem1);
            this.ribbonPageGroup1.ItemLinks.Add(this.switchToWeekViewItem1);
            this.ribbonPageGroup1.ItemLinks.Add(this.switchToFullWeekViewItem1);
            this.ribbonPageGroup1.ItemLinks.Add(this.switchToMonthViewItem1);
            this.ribbonPageGroup1.ItemLinks.Add(this.switchToTimelineViewItem1);
            this.ribbonPageGroup1.ItemLinks.Add(this.switchToGanttViewItem1);
            this.ribbonPageGroup1.ItemLinks.Add(this.switchToAgendaViewItem1);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Active View";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.switchTimeScalesItem1);
            this.ribbonPageGroup2.ItemLinks.Add(this.changeScaleWidthItem1);
            this.ribbonPageGroup2.ItemLinks.Add(this.switchTimeScalesCaptionItem1);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Time Scale";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.switchCompressWeekendItem1);
            this.ribbonPageGroup3.ItemLinks.Add(this.switchShowWorkTimeOnlyItem1);
            this.ribbonPageGroup3.ItemLinks.Add(this.switchCellsAutoHeightItem1);
            this.ribbonPageGroup3.ItemLinks.Add(this.changeSnapToCellsUIItem1);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "Layout";
            // 
            // ucNotifikacije
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.schedulerControl1);
            this.Controls.Add(this.dateNavigator);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "ucNotifikacije";
            this.Size = new System.Drawing.Size(907, 651);
            this.Load += new System.EventHandler(this.frmNotifikacije_Load);
            this.VisibleChanged += new System.EventHandler(this.ucNotifikacije_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kadrovskaDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resourcesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerBarController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraScheduler.DateNavigator dateNavigator;
        private DevExpress.XtraScheduler.SchedulerControl schedulerControl1;
        private DevExpress.XtraScheduler.SchedulerStorage schedulerStorage1;
        private System.Windows.Forms.BindingSource appointmentsBindingSource;
        private KadrovskaDataSet kadrovskaDataSet;
        private System.Windows.Forms.BindingSource resourcesBindingSource;
        private DevExpress.XtraScheduler.UI.SwitchToDayViewItem switchToDayViewItem1;
        private DevExpress.XtraScheduler.UI.SwitchToWorkWeekViewItem switchToWorkWeekViewItem1;
        private DevExpress.XtraScheduler.UI.SwitchToWeekViewItem switchToWeekViewItem1;
        private DevExpress.XtraScheduler.UI.SwitchToFullWeekViewItem switchToFullWeekViewItem1;
        private DevExpress.XtraScheduler.UI.SwitchToMonthViewItem switchToMonthViewItem1;
        private DevExpress.XtraScheduler.UI.SwitchToTimelineViewItem switchToTimelineViewItem1;
        private DevExpress.XtraScheduler.UI.SwitchToGanttViewItem switchToGanttViewItem1;
        private DevExpress.XtraScheduler.UI.SwitchToAgendaViewItem switchToAgendaViewItem1;
        private DevExpress.XtraScheduler.UI.SwitchTimeScalesItem switchTimeScalesItem1;
        private DevExpress.XtraScheduler.UI.ChangeScaleWidthItem changeScaleWidthItem1;
        private DevExpress.XtraScheduler.UI.SwitchTimeScalesCaptionItem switchTimeScalesCaptionItem1;
        private DevExpress.XtraScheduler.UI.SwitchCompressWeekendItem switchCompressWeekendItem1;
        private DevExpress.XtraScheduler.UI.SwitchShowWorkTimeOnlyItem switchShowWorkTimeOnlyItem1;
        private DevExpress.XtraScheduler.UI.SwitchCellsAutoHeightItem switchCellsAutoHeightItem1;
        private DevExpress.XtraScheduler.UI.ChangeSnapToCellsUIItem changeSnapToCellsUIItem1;
        private KadrovskaDataSetTableAdapters.AppointmentsTableAdapter appointmentsTableAdapter;
        private KadrovskaDataSetTableAdapters.ResourcesTableAdapter resourcesTableAdapter;
        private DevExpress.XtraScheduler.UI.SchedulerBarController schedulerBarController1;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
    }
}