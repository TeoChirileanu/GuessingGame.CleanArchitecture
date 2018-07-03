import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  private Number: number;
  private Message: string;
  private Logs: string[];
  private GameOver: boolean;
  private Http: HttpClient;

  constructor(private http: HttpClient) {
    this.http = http;
  }

  public CheckNumber(): void {
    if (!this.IsValid(this.Number)) return;
    this.http.get<GameResponse>('http://localhost:5000/api/checknumber?number=' + this.Number).subscribe((data: GameResponse) => {
      this.Number = undefined;
      var inputBox = document.getElementById('InputBox');
      inputBox.setAttribute('placeholder', 'Try again!');
      this.Message = data['content'];
      if (this.Message.includes('Correct!')) {
        inputBox.setAttribute('placeholder', 'Congratulations!');
        this.GameOver = true;
        inputBox.setAttribute('disabled', 'true');
      }
    });
  }

  public ShowLogs(): void {
    this.http.get<GameResponse>('http://localhost:5000/api/showlogs').subscribe((data: GameResponse) => {
      this.Logs = data['content'].split('\r\n');
    });
  }

  public PlayAgain(): void {
    location.reload();
  }

  private IsValid(number: number): boolean {
    if (Math.abs(this.Number) > 2147483647 || this.Number == null) { 
      this.Message = 'Invalid number';
      return false;
    }
    return true;
  }
}

interface GameResponse {
  content: string;
}
