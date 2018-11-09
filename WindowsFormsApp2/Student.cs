using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class Student
    {
        private int _ID;
        private int _ProtNum;

        private StringMultiLanguage _lastname;
        private StringMultiLanguage _firstname;
        private StringMultiLanguage _prevDocument;
        private StringMultiLanguage _durationOfTraining;
        private StringMultiLanguage _QualificationAwarded;

       
        private String _serialDiploma;
        private String _numberDiploma;
        private String _numberAddition;
        private String _prevSerialNumberAddition;
        private String _IssuedBy;

        private DateTime _birthday;
        private DateTime _dateStart;
        private DateTime _dateEnd;
        private DateTime _DecisionDate;


        public Student()
        {
            this._ID = 0;
            this._ProtNum = 0;
            
            this._lastname = new StringMultiLanguage();
            this._firstname = new StringMultiLanguage();
            this._prevDocument = new StringMultiLanguage();
            this._durationOfTraining = new StringMultiLanguage();
            this._QualificationAwarded = new StringMultiLanguage();

           
            this._serialDiploma = "";
            this._numberDiploma = "";
            this._numberAddition = "";
            this._prevSerialNumberAddition = "";
            this._IssuedBy = "";

            this._birthday = new DateTime();
            this._DecisionDate = new DateTime();
            this._dateStart = new DateTime();
            this._dateEnd = new DateTime();


        }

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public int ProtNum
        {
            get { return _ProtNum; }
            set { _ProtNum = value; }
        }

        public StringMultiLanguage Firstname
        {
            get { return _firstname; }
            set { _firstname = value; }
        }

        public StringMultiLanguage QualificationAwarded
        {
            get { return _QualificationAwarded; }
            set { _QualificationAwarded = value; }
        }

        public StringMultiLanguage Lastname
        {
            get { return _lastname; }
            set { _lastname = value; }
        }

        public StringMultiLanguage PrevDocument
        {
            get { return _prevDocument; }
            set { _prevDocument = value; }
        }

        public StringMultiLanguage DurationOfTraining
        {
            get { return _durationOfTraining; }
            set { _durationOfTraining = value; }
        }

        public String IssuedBy
        {
            get { return _IssuedBy; }
            set { _IssuedBy = value; }
        }

        public String SerialDiploma
        {
            get { return _serialDiploma; }
            set { _serialDiploma = value; }
        }

        public String NumberDiploma
        {
            get { return _numberDiploma; }
            set { _numberDiploma = value; }
        }

        public String PrevSerialNumberAddition
        {
            get { return _prevSerialNumberAddition; }
            set { _prevSerialNumberAddition = value; }
        }


        public String NumberAddition
        {
            get { return _numberAddition; }
            set { _numberAddition = value; }
        }

        public DateTime Birthday
        {
            get { return _birthday; }
            set { _birthday = value; }
        }

        public DateTime DecisionDate
        {
            get { return _DecisionDate; }
            set { _DecisionDate = value; }
        }

        public DateTime dateStart
        {
            get { return _dateStart; }
            set { _dateStart = value; }
        }
        public DateTime dateEnd
        {
            get { return _dateEnd; }
            set { _dateEnd = value; }
        }
    }
}
