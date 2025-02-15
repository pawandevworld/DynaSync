import { Component, inject, input, output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-register',
  imports: [FormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  //Injecting the account service needed to register a user
  private accountService = inject(AccountService);

  //since child component is receiving somthing from parent component
  //we need to use the @Input() decorator
  //@Input() usersFromHomeComponent: any;
  //New approach starting Angular 17.3 onwards
  //This is a Inputsignal  (Parent to child)
  //usersFromHomeComponent = input.required<any>();

  //also emiting the event from the child component to the parent component
  //we need to use the @Output() decorator
  //@Output() cancelRegister = new EventEmitter();
    //New approach starting Angular 17.3 onwards
    //This is a Outputsignal  (Parent to child)
  cancelRegister = output<boolean>();

  model: any = {}

  register() {
    //console.log(this.model);
    this.accountService.register(this.model).subscribe({
      next: response => 
        {
          console.log(response);
          this.cancel();
        },
        error: error => console.log(error)
    })
  }

  cancel() {
    this.cancelRegister.emit(false);
  }
}
