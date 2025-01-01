// src/app/components/contact-list/contact-list.component.ts

import { Component, OnInit } from '@angular/core';
import { ContactService } from '../../core/services/contact.service';
import { Contact } from '../../models/contact.model';

@Component({
  selector: 'app-contact-list',
  templateUrl: './contact-list.component.html',
  styleUrls: ['./contact-list.component.css']
})
export class ContactListComponent implements OnInit {
  contacts: Contact[] = [];
  errorMessage: string | null = null;

  constructor(private contactService: ContactService) {}

  ngOnInit(): void {
    this.loadContacts();
  }

  loadContacts(): void {
    this.contactService.listAll().subscribe({
      next: (data) => (this.contacts = data),
      error: (err) => (this.errorMessage = 'Failed to load contacts'),
    });
  }

  deleteContact(id: number): void {
    this.contactService.deleteContact(id).subscribe({
      next: () => (this.contacts = this.contacts.filter(contact => contact.id !== id)),
      error: (err) => (this.errorMessage = `Failed to delete contact with ID ${id}`),
    });
  }
}
