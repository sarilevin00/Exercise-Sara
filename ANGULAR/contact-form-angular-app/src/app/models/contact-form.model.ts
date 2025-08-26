export interface ContactForm {
    id?: number;
    name: string;
    phone: string;
    email: string;
    departments: string;
    description: string;
    submissionDate?: Date;
}