using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Calculator
{
    public class CalculatorVM: BaseVM
    {
        Operation _Op = new BinaryOperation();
        public Operation Op
        {
            get { return _Op; }
            set { _Op = value; OnPropertyChanged(); }
        }
        ObservableCollection<Operation> _Operations = new ObservableCollection<Operation>();
        public ObservableCollection<Operation> Operations
        {
            get { return _Operations; }
            set { _Operations = value; OnPropertyChanged(); }
        }

<<<<<<< HEAD
        DelegateCommand _Clear;
=======
        GenericCommand _Clear;
>>>>>>> 7481e5f34c39fdf1c49e39b833257775c43ee000
        public ICommand Clear
        {
            get
            {
                if (_Clear == null) {
<<<<<<< HEAD
                    _Clear = new DelegateCommand {
=======
                    _Clear = new GenericCommand {
>>>>>>> 7481e5f34c39fdf1c49e39b833257775c43ee000
                        ExecuteFunction = x => {
                            Operations.Clear();
                            Op = new BinaryOperation { };
                        },
                        CanExecuteFunction = x => Operations.Any()
                    };
                    _Operations.CollectionChanged += (s, e) => _Clear.OnCanExecuteChanged();
                }
                return _Clear;
            }
        } 

    }
}
