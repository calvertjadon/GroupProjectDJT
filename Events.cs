﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GroupProjectDJT
{
    public partial class Events : MenuForm
    {
        public override Panel MainPanel => eventsPanel;

        public Events()
        {
            InitializeComponent();
        }
    }
}