﻿using System.Windows;
using System.Windows.Data;
using System.Windows.Interactivity;

namespace Dev2.CustomControls.Behavior
{
    public class ActualSizeBindingBehavior : Behavior<FrameworkElement>
    {
        public double HorizontalOffset
        {
            get { return (double)GetValue(HorizontalOffsetProperty); }
            set { SetValue(HorizontalOffsetProperty, value); }
        }

        public static readonly DependencyProperty HorizontalOffsetProperty =
            DependencyProperty.Register("HorizontalOffset", typeof(double), 
            typeof(ActualSizeBindingBehavior), new PropertyMetadata(0D));

        public double VerticalOffset
        {
            get { return (double)GetValue(VerticalOffsetProperty); }
            set { SetValue(VerticalOffsetProperty, value); }
        }

        public static readonly DependencyProperty VerticalOffsetProperty =
            DependencyProperty.Register("VerticalOffset", typeof(double), 
            typeof(ActualSizeBindingBehavior), new PropertyMetadata(0D));       

        public double ActualHeight
        {
            get { return (double)GetValue(ActualHeightProperty); }
            set { SetValue(ActualHeightProperty, value); }
        }

        public static readonly DependencyProperty ActualHeightProperty =
            DependencyProperty.Register("ActualHeight", typeof (double),
                                        typeof (ActualSizeBindingBehavior),
                                        new PropertyMetadata(0D));

        public double ActualWidth
        {
            get { return (double)GetValue(ActualWidthProperty); }
            set { SetValue(ActualWidthProperty, value); }
        }

        public static readonly DependencyProperty ActualWidthProperty =
            DependencyProperty.Register("ActualWidth", typeof(double), 
            typeof(ActualSizeBindingBehavior), new PropertyMetadata(0D));


        protected override void OnAttached()
        {
            base.OnAttached();
            SetSize();
            AttachEvents();
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            DetachEvents();
        }

        private void DetachEvents()
        {
            AssociatedObject.SizeChanged -= SizeChanged;
        }

        private void AttachEvents()
        {
            AssociatedObject.SizeChanged += SizeChanged;
        }

        private void SizeChanged(object sender, SizeChangedEventArgs e)
        {
            SetSize();
        }

        private void SetSize()
        {
            ActualHeight = AssociatedObject.ActualHeight - VerticalOffset;
            ActualWidth = AssociatedObject.ActualWidth - HorizontalOffset;
        }
             
        /// <summary>
        /// Gets a multibinding that determines the max size of the two behaviors passed in
        /// </summary>
        /// <param name="actualSizeBehavior">The actual size behavior.</param>
        /// <param name="overlaySizeBindingBehavior">The overlay size binding behavior.</param>
        /// <param name="converter">The converter.</param>
        /// <returns></returns>
        /// <author>Jurie.smit</author>
        /// <date>2013/07/24</date>
        public static MultiBinding GetWidthMultiBinding(ActualSizeBindingBehavior actualSizeBehavior,
                                                  ActualSizeBindingBehavior overlaySizeBindingBehavior,
                                                  IMultiValueConverter converter)
        {
            var maxBinding = new MultiBinding
            {
                Converter = converter
            };

            var actualWidthBinding = new Binding
            {
                Source = actualSizeBehavior,
                Path = new PropertyPath("ActualWidth"),
                Mode = BindingMode.TwoWay
            };
            maxBinding.Bindings.Add(actualWidthBinding);

            if (overlaySizeBindingBehavior != null)
            {
                var overlayWidthBinding = new Binding
                {
                    Source = overlaySizeBindingBehavior,
                    Path = new PropertyPath("ActualWidth"),
                    Mode = BindingMode.TwoWay
                };
                maxBinding.Bindings.Add(overlayWidthBinding);
            }
            return maxBinding;
        }
    }
}
