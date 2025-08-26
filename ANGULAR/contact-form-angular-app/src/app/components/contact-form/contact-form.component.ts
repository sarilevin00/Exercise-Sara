import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ApiService } from '../../services/api.service';
import { ContactForm } from '../../models/contact-form.model';

@Component({
  selector: 'app-contact-form',
  templateUrl: './contact-form.component.html',
  styleUrls: ['./contact-form.component.scss']
})
export class ContactFormComponent {
  contactForm: FormGroup;

  constructor(private fb: FormBuilder, private apiService: ApiService) {
    this.contactForm = this.fb.group({
      name: ['', Validators.required],
      phone: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      departments: ['', Validators.required],
      description: ['', Validators.required]
    });
  }

  onSubmit() {
    if (this.contactForm.valid) {
      const formData: ContactForm = this.contactForm.value;
      this.apiService.submitContactForm(formData).subscribe(response => {
        console.log('Form submitted successfully', response);
        this.contactForm.reset();
      }, error => {
        console.error('Error submitting form', error);
      });
    }
  }
}