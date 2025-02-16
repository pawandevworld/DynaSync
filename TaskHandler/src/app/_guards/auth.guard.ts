import { inject } from '@angular/core';
import { CanActivateFn } from '@angular/router';
import { AccountService } from '../_services/account.service';
import { ToastrService } from 'ngx-toastr';

//Since we are not in a class component we can't use the constructor @Injectable decorator
//this is a normal javascript/typescript function so we will use the const/let keyword to 
//define the function
export const authGuard: CanActivateFn = (route, state) => {
  const accountService = inject(AccountService);
  const toastr = inject(ToastrService);

  //since this is a route gaurd this need to be conficured in the route configuration
  //inside the app.routes.ts file
  if (accountService.currentUser()) {
    return true;
  } else {
    toastr.error('unauthorized access detected');
    return false;
  }
};
