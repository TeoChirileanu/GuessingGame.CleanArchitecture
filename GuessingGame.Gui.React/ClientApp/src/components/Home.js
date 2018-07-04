import React, { Component } from 'react';

export class Home extends Component {
  displayName = Home.name

    constructor(props) {
        super(props);
        this.state = { number: '', message: '', logs: [], gameOver: false }
        this.HandleChange = this.HandleChange.bind(this);
        this.CheckNumber = this.CheckNumber.bind(this);
        this.HandleKeyPress = this.HandleKeyPress.bind(this);
        this.ShowLogs = this.ShowLogs.bind(this);
        this.PlayAgain = this.PlayAgain.bind(this);
    }

    CheckNumber() {
        fetch(`api/checknumber?number=${this.state.number}`)
            .then(response => response.json())
            .then(response => {
                this.setState({ message: response['content'], number: '' });
                if (this.state.message.includes('Correct!')) {
                    document.getElementById('ShowLogsButton').hidden = false;
                    document.getElementById('PlayAgainButton').hidden = false;
                }
            });
    }

    ShowLogs() {
        fetch('api/showlogs')
            .then(response => response.json())
            .then(response => {
                this.setState({ logs: response['content']});
            });
        this.state.message = '';
        document.getElementById('InputBox').disabled = true;
        document.getElementById('ShowLogsButton').hidden = true;
        document.getElementById('CheckNumberButton').hidden = true;
    }

    PlayAgain() {
        window.location.reload();
    }

    HandleChange(e) {
        this.setState({ number: e.target.value });
    }

    HandleKeyPress(e) {
        if (e.key === 'Enter') {
            this.CheckNumber();
        }
    }

  render() {
      return (
          <div>
              <label>Guess my number:</label><br/>
              <input id="InputBox" type="number" value={this.state.number}
      placeholder="Good luck!" onChange={this.HandleChange} autoFocus
                  onKeyPress={this.HandleKeyPress}/><br />
              <button id="CheckNumberButton" onClick={this.CheckNumber}>Check</button><br />
              <p>{this.state.message}</p>
              <button id="ShowLogsButton" onClick={this.ShowLogs} hidden>Show Logs</button><br />
              <div>{this.state.logs}</div>
              <div>
                  <button id="PlayAgainButton" onClick={this.PlayAgain} hidden>Play Again</button>
            </div>
          </div>
    );
}
}
