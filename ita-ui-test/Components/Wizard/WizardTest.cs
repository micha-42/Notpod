﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Rhino.Mocks;
using System.Windows.Forms;

namespace iTunesAgent.UI.Components.Wizard
{    

    [TestFixture]
    public class WizardTest
    {

        //[Test]
        //[ExpectedException(typeof(NoWizardPagesException))]
        //public void StartWizard_WhenNoPagesAdded_ShouldThrowException()
        //{
        //    Wizard wizard = new Wizard();
        //    wizard.StartWizard(null);
        //}

        //[Test]
        //public void StartWizard_WhenConditionsAreMet_ShouldCallShowDialogOnForm()
        //{
        //    MockRepository mock = new MockRepository();

        //    Wizard wizard = new Wizard();
        //    IWizardFormFactory formFactory = mock.StrictMock<IWizardFormFactory>();
        //    WizardForm mockForm = mock.StrictMock<WizardForm>();

        //    AbstractWizardPage page = mock.StrictMock<AbstractWizardPage>();
        //    //page.Expect(x => x.DataStore).Repeat.Once();
        //    wizard.Pages.AddFirst(page);

        //    wizard.WizardFormFactory = formFactory;

        //    Expect.Call(formFactory.NewForm()).Return(mockForm);
        //    Expect.Call(mockForm.ShowDialog()).Return(DialogResult.OK);
        //    Expect.Call(mockForm.CancelButtonObject).Return(new Button());
        //    Expect.Call(mockForm.BackButton).Return(new Button());
        //    Expect.Call(mockForm.NextButton).Return(new Button());
        //    Expect.Call(mockForm.FinishButton).Return(new Button());

        //    mock.ReplayAll();

        //    wizard.StartWizard(null);

        //    mock.VerifyAll();
        //}

        [Test]
        public void buttonCancel_Click_ShouldCallCloseOnActiveForm()
        {
            MockRepository mock = new MockRepository();

            Wizard wizard = new Wizard();
            IWizardFormFactory formFactory = mock.StrictMock<IWizardFormFactory>();
            WizardForm mockForm = mock.StrictMock<WizardForm>();

            DummyPage page = new DummyPage();
            
            wizard.Pages.AddFirst(page);

            wizard.WizardFormFactory = formFactory;
            SetUpCommonExpectations(formFactory, mockForm);                        
            
            Expect.Call(mockForm.Close);

            mock.ReplayAll();

            wizard.StartWizard(null);

            Button button = new Button();
            EventArgs e = new EventArgs();
            wizard.buttonCancel_Click(button, e);

            mock.VerifyAll();
        }

        private static void SetUpCommonExpectations(IWizardFormFactory formFactory, WizardForm mockForm)
        {
            Expect.Call(formFactory.NewForm()).Return(mockForm);
            Expect.Call(mockForm.ShowDialog()).Return(DialogResult.OK);
            Expect.Call(mockForm.CancelButtonObject).Return(new Button());
            Expect.Call(mockForm.BackButton).Repeat.Times(2).Return(new Button());
            Expect.Call(mockForm.NextButton).Return(new Button());
            Expect.Call(mockForm.FinishButton).Return(new Button());

       }

        //[Test]
        //public void buttonNext_Click_WhenNotOnLastPage_ShouldInvokeNextPageInPageList()
        //{

        //    MockRepository mock = new MockRepository();

        //    Wizard wizard = new Wizard();
        //    IWizardFormFactory formFactory = mock.StrictMock<IWizardFormFactory>();
        //    WizardForm mockForm = mock.StrictMock<WizardForm>();

        //    AbstractWizardPage page = mock.StrictMock<AbstractWizardPage>();
        //    wizard.Pages.AddFirst(page);

        //    AbstractWizardPage secondPage = mock.StrictMock<AbstractWizardPage>();
        //    wizard.Pages.AddFirst(secondPage);

        //    wizard.WizardFormFactory = formFactory;
        //    SetUpCommonExpectations(formFactory, mockForm);

        //    //Expect.Call(page.DataStore);
        //    //Expect.Call(page.Populate);
        //    //Expect.Call(secondPage.DataStore);
        //    //Expect.Call(secondPage.Populate);
        //    Expect.Call(secondPage.BackEnabled).Return(true);
        //    Expect.Call(secondPage.NextEnabled).Return(true);
        //    Expect.Call(secondPage.FinishEnabled).Return(true);

        //    mock.ReplayAll();

        //    wizard.StartWizard(null);

        //    Button button = new Button();
        //    EventArgs eventargs = new EventArgs();
        //    wizard.buttonNext_Click(button, eventargs);

        //    mock.VerifyAll();
        //}

    }
}