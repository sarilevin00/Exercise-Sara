import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { ContactForm } from '../models/contact-form.model';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private apiUrl = `${environment.apiBaseUrl}/api/contactform`;

  constructor(private http: HttpClient) { }

  submitContactForm(contactForm: ContactForm): Observable<ContactForm> {
    return this.http.post<ContactForm>(this.apiUrl, contactForm);
  }

  getMonthlyReport(): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/monthlyreport`);
  }
}