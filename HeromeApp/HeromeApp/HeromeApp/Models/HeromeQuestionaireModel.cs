using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace HeromeApp.Models
{
	public class HeromeQuestionaireModel : INotifyPropertyChanged
	{
		#region Answer model
		public class Answer
		{
			public string Caption { get; set; }
		}
		#endregion

		#region Question model
		public class Question
		{
			public string Caption { get; set; }
			public List<Answer> Answers { get; set; }
		}
		#endregion

		#region Result model
		public class Result
		{
			public List<int> Options { get; set; }
			public string Url { get; set; }
		}
		#endregion

		#region Events
		public event PropertyChangedEventHandler PropertyChanged;
		#endregion

		#region Properties and fields
		public ObservableCollection<Question> Questions { get; }
		public ObservableCollection<Result> Results { get; }

		private int _currentQuestionIndex;
		public Question ActiveQuestion { get { return Questions[_currentQuestionIndex]; } }
		#endregion

		#region Constructors
		public HeromeQuestionaireModel(List<Question> questions, List<Result> results)
		{
			if (questions.Count == 0)
			{
				throw new ArgumentException("The questions list contains no elements!");
			}
			if (results.Count == 0)
			{
				throw new ArgumentException("The results list contains no elements!");
			}
			this.Questions = new ObservableCollection<Question>(questions);
			this.Results = new ObservableCollection<Result>(results);

			this._currentQuestionIndex = 0;
			this.Questions.CollectionChanged += Questions_CollectionChanged;
			this.Results.CollectionChanged += Results_CollectionChanged;
		}
		#endregion

		#region Public methods
		public bool HasPrevious()
		{
			return _currentQuestionIndex > 0;
		}

		public bool HasNext()
		{
			return (_currentQuestionIndex + 1) < Questions.Count;
		}

		public void Previous()
		{
			if (!HasPrevious()) return;
			_currentQuestionIndex--;
			PropertyChanged(this, new PropertyChangedEventArgs(nameof(ActiveQuestion)));
		}

		public void Next()
		{
			if (!HasNext()) return;
			_currentQuestionIndex++;
			PropertyChanged(this, new PropertyChangedEventArgs(nameof(ActiveQuestion)));
		}

		public string GetResultingUrl()
		{
			return "https://www.google.com";
		}
		#endregion

		#region Control events
		private void Questions_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Questions)));
		}
		private void Results_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Results)));
		}
		#endregion
	}
}
