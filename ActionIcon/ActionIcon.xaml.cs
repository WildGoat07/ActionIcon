using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ActionIcon
{
    public partial class ActionIcon : UserControl
    {
        public static readonly DependencyProperty ActionProperty = DependencyProperty.Register(
            nameof(Action),
            typeof(Icon),
            typeof(ActionIcon),
            new FrameworkPropertyMetadata(Icon.NONE, FrameworkPropertyMetadataOptions.AffectsRender));

        public static readonly DependencyProperty ActionSourceProperty = DependencyProperty.Register(
            nameof(ActionSource),
            typeof(ImageSource),
            typeof(ActionIcon),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));

        public static readonly DependencyProperty BaseSourceProperty = DependencyProperty.Register(
            nameof(BaseSource),
            typeof(ImageSource),
            typeof(ActionIcon),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));

        public static readonly DependencyProperty ModifierProperty = DependencyProperty.Register(
            nameof(Modifier),
            typeof(Icon),
            typeof(ActionIcon),
            new FrameworkPropertyMetadata(Icon.NONE, FrameworkPropertyMetadataOptions.AffectsRender));

        public static readonly DependencyProperty ModifierSourceProperty = DependencyProperty.Register(
            nameof(ModifierSource),
            typeof(ImageSource),
            typeof(ActionIcon),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));

        public static readonly DependencyProperty StatusProperty = DependencyProperty.Register(
            nameof(Status),
            typeof(Icon),
            typeof(ActionIcon),
            new FrameworkPropertyMetadata(Icon.NONE, FrameworkPropertyMetadataOptions.AffectsRender));

        public static readonly DependencyProperty StatusSourceProperty = DependencyProperty.Register(
            nameof(StatusSource),
            typeof(ImageSource),
            typeof(ActionIcon),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));

        public ActionIcon()
        {
            InitializeComponent();
        }

        [Description("Icon in the top left."), Category("Appearance")]
        public Icon Action
        {
            get => (Icon)GetValue(ActionProperty);
            set => SetValue(ActionProperty, value);
        }

        [Description("Custom source for the icon in the top left. The Action property will have no effect."), Category("Appearance")]
        public ImageSource ActionSource
        {
            get => (ImageSource)GetValue(ActionSourceProperty);
            set => SetValue(ActionSourceProperty, value);
        }

        [Description("Source of the main icon."), Category("Appearance")]
        public ImageSource BaseSource
        {
            get => (ImageSource)GetValue(BaseSourceProperty);
            set => SetValue(BaseSourceProperty, value);
        }

        [Description("Icon in the bottom left."), Category("Appearance")]
        public Icon Modifier
        {
            get => (Icon)GetValue(ModifierProperty);
            set => SetValue(ModifierProperty, value);
        }

        [Description("Custom source for the icon in the bottom left. The Modifier property will have no effect."), Category("Appearance")]
        public ImageSource ModifierSource
        {
            get => (ImageSource)GetValue(ModifierSourceProperty);
            set => SetValue(ModifierSourceProperty, value);
        }

        [Description("Icon in the bottom right."), Category("Appearance")]
        public Icon Status
        {
            get => (Icon)GetValue(StatusProperty);
            set => SetValue(StatusProperty, value);
        }

        [Description("Custom source for the icon in the bottom right. The Status property will have no effect."), Category("Appearance")]
        public ImageSource StatusSource
        {
            get => (ImageSource)GetValue(StatusSourceProperty);
            set => SetValue(StatusSourceProperty, value);
        }

        private Data Data => (Data)DataContext;

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (e.Property == BaseSourceProperty)
                Data.BaseSource = (ImageSource)e.NewValue;
            else if (e.Property == ActionSourceProperty)
                Data.ActionSource = (ImageSource)e.NewValue;
            else if (e.Property == StatusSourceProperty)
                Data.StatusSource = (ImageSource)e.NewValue;
            else if (e.Property == ModifierSourceProperty)
                Data.ModifierSource = (ImageSource)e.NewValue;
            else if (e.Property == ActionProperty && ActionSource == null)
                Data.ActionSource = TryFindResource(GetIconKey((Icon)e.NewValue)) as ImageSource;
            else if (e.Property == StatusProperty && StatusSource == null)
                Data.StatusSource = TryFindResource(GetIconKey((Icon)e.NewValue)) as ImageSource;
            else if (e.Property == ModifierProperty && ModifierSource == null)
                Data.ModifierSource = TryFindResource(GetIconKey((Icon)e.NewValue)) as ImageSource;
        }

        private string GetIconKey(Icon icon) => icon switch
        {
            Icon.NONE => "None",
            Icon.ADD => "Add",
            Icon.ALERT => "Alert",
            Icon.DELETE => "Delete",
            Icon.DOWNLOAD => "Download",
            Icon.EDIT => "Edit",
            Icon.EDIT_REVERSE => "EditReverse",
            Icon.ERROR => "Error",
            Icon.FIND => "Find",
            Icon.HELP => "Help",
            Icon.IMPORT => "Import",
            Icon.INFO => "Info",
            Icon.LOCK => "Lock",
            Icon.NEW => "New",
            Icon.NEXT => "Next",
            Icon.NO => "No",
            Icon.OK => "Ok",
            Icon.OPEN => "Open",
            Icon.PAUSE => "Pause",
            Icon.PREVIOUS => "Previous",
            Icon.REMOVE => "Remove",
            Icon.RUN => "Run",
            Icon.STOP => "Stop",
            Icon.SYNC => "Sync",
            Icon.UPLOAD => "Upload",
            Icon.WARNING => "Warning",
            _ => null,
        };
    }

    internal class Data : INotifyPropertyChanged
    {
        private ImageSource actionSource;
        private ImageSource baseSource;
        private ImageSource modifierSource;
        private ImageSource statusSource;

        public Data()
        {
            actionSource = null;
            baseSource = null;
            modifierSource = null;
            statusSource = null;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ImageSource ActionSource
        {
            get => actionSource;
            set
            {
                if (actionSource != value)
                {
                    actionSource = value;
                    OnPropertyChanged(nameof(ActionSource));
                }
            }
        }

        public ImageSource BaseSource
        {
            get => baseSource;
            set
            {
                if (baseSource != value)
                {
                    baseSource = value;
                    OnPropertyChanged(nameof(BaseSource));
                }
            }
        }

        public ImageSource ModifierSource
        {
            get => modifierSource;
            set
            {
                if (modifierSource != value)
                {
                    modifierSource = value;
                    OnPropertyChanged(nameof(ModifierSource));
                }
            }
        }

        public ImageSource StatusSource
        {
            get => statusSource;
            set
            {
                if (statusSource != value)
                {
                    statusSource = value;
                    OnPropertyChanged(nameof(StatusSource));
                }
            }
        }

        protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}