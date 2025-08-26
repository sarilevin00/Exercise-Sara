import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../services/api.service';

@Component({
  selector: 'app-monthly-report',
  templateUrl: './monthly-report.component.html',
  styleUrls: ['./monthly-report.component.scss']
})
export class MonthlyReportComponent implements OnInit {
  monthlyReport: any[] = [];

  constructor(private apiService: ApiService) {}

  ngOnInit(): void {
    this.getMonthlyReport();
  }

  getMonthlyReport(): void {
    this.apiService.getMonthlyReport().subscribe(
      (data: any[]) => {
        this.monthlyReport = data;
      },
      (error) => {
        console.error('Error fetching monthly report', error);
      }
    );
  }
}