﻿using Addressbook.DAL;
using Addressbook.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ContactBAL
/// </summary>
namespace Addressbook.BAL
{
    public class ContactBAL
    {
        #region constructor
        public ContactBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor

        #region Local Variables : Message
        protected String _Message;
        public String Message
        {
            get { return _Message; }
            set { _Message = value; }
        }
        #endregion Local Variables : Message

        #region InsertContact
        public Boolean InsertContact(ContactENT entContact)
        {
            ContactDAL dalContact = new ContactDAL();
            if (dalContact.InsertContact(entContact))
            {
                return true;
            }
            else
            {
                Message = dalContact.Message;
                return false;
            }

        }
        #endregion InsertContact

        #region DeleteContact
        public Boolean DeleteContact(SqlInt32 ContactID, SqlInt32 UserID)
        {
            ContactDAL dalContact = new ContactDAL();
            if (dalContact.DeleteContact(ContactID, UserID))
            {
                return true;
            }
            else
            {
                Message = dalContact.Message;
                return false;
            }
        }
        #endregion DeleteContact

        #region UpdateContact
        public Boolean UpdateContact(ContactENT entContact)
        {
            ContactDAL dalContact = new ContactDAL();
            if (dalContact.UpdateContact(entContact))
            {
                return true;
            }
            else
            {
                Message = dalContact.Message;
                return false;
            }
        }
        #endregion UpdateContact

        #region SelectAll
        public DataTable SelectAll(SqlInt32 UserID)
        {
            ContactDAL dalContact = new ContactDAL();
            return dalContact.SelectAll(UserID);
        }
        #endregion SelectAll

        #region SelectByPK
        public ContactENT SelectByPK(SqlInt32 ContactID, SqlInt32 UserID)
        {
            ContactDAL dalContact = new ContactDAL();
            return dalContact.SelectByPK(ContactID, UserID);
        }
        #endregion SelectByPK

        #region UpdateImage
        public Boolean UpdateImage(ContactENT entContact)
        {
            ContactDAL dalContact = new ContactDAL();
            if (dalContact.UpdateImage(entContact))
            {
                return true;
            }
            else
            {
                Message = dalContact.Message;
                return false;
            }
        }
        #endregion UpdateIamge

        #region DeleteImage
        public Boolean DeleteImage(SqlInt32 ContactID, SqlInt32 UserID)
        {
            ContactDAL dalContact = new ContactDAL();
            if (dalContact.DeleteImage(ContactID, UserID))
            {
                return true;
            }
            else
            {
                Message = dalContact.Message;
                return false;
            }
        }
        #endregion DeleteIamge
    }
}