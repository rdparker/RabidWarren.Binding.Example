﻿// -----------------------------------------------------------------------
//  <copyright file="ViewModel.cs" company="Ron Parker">
//   Copyright 2014 Ron Parker
//  </copyright>
//  <summary>
//   Implements the View Model for the PortableBinding application.
//  </summary>
// -----------------------------------------------------------------------

namespace ViewModel
{
    using Binding;
    using Model;

    /// <summary>
    /// Represents the PortableBinding application's View Model.
    /// </summary>
    public class ViewModel : ObservableObject
    {
        /// <summary>
        /// The Model this View Model presents.
        /// </summary>
        private Model _model = new Model();

        /// <summary>
        /// Initializes static members of the <see cref="ViewModel"/> class, registering its properties.
        /// </summary>
        static ViewModel()
        {
            PropertyRegistry.Add(
                "Number",
                (ViewModel vm) => { return vm.Number; },
                (ViewModel vm, int value) => vm.Number = value);

            PropertyRegistry.Add(
                "Text",
                (ViewModel vm) => { return vm.Text; },
                (ViewModel vm, string value) => vm.Text = value);

            PropertyRegistry.Add(
                "Computed",
                (ViewModel vm) => { return vm.Computed; });
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            // Fire a change notification for the Computed property when anything else changes..
            PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName != "Computed")
                    OnPropertyChangedEvent("Computed");
            };
        }

        /// <summary>
        /// Gets or sets the View Model's number property.
        /// </summary>
        /// <value>
        /// The View Model's number property.
        /// </value>
        public int Number
        {
            get { return _model.Number; }
            set { _model.Number = value; }
        }

        /// <summary>
        /// Gets or sets the View Model's text property.
        /// </summary>
        /// <value>
        /// The View Model's text property.
        /// </value>
        public string Text
        {
            get { return _model.Text; }
            set
            { 
                _model.Text = value;
            }
        }

        /// <summary>
        /// Gets the View Model's computed property.
        /// </summary>
        /// <value>
        /// The View Model's computed property.
        /// </value>
        public string Computed
        {
            get { return _model.Text + ": " + _model.Number; }
        }
    }
}
