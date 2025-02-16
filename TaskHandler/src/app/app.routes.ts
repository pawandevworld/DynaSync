import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MemberListComponent } from './members/member-list/member-list.component';
import { MemberDetailComponent } from './members/member-detail/member-detail.component';
import { ListComponent } from './list/list.component';
import { MessagesComponent } from './messages/messages.component';
import { authGuard } from './_guards/auth.guard';

//this is where we define our routes of type Routes and they are contained in an array
export const routes: Routes = [
    {path: '', component: HomeComponent},
    {path: '', 
        runGuardsAndResolvers: 'always', 
        canActivate: [authGuard], 
        children: [

            {path: 'members', component: MemberListComponent},
            {path: 'members/:id', component: MemberDetailComponent},
            {path: 'lists', component: ListComponent},
            {path: 'messages', component: MessagesComponent},
]},

    //Since we can have long list of routes and we dont want to enter the authGuard for each route
    //there is a easier way to do this by using the children property of the route object
    //we will move all thses routes inside the children property of the route object above
    // {path: 'members', component: MemberListComponent,canActivate:[authGuard]},
    // {path: 'members/:id', component: MemberDetailComponent},
    // {path: 'lists', component: ListComponent},
    // {path: 'messages', component: MessagesComponent},
     {path: '**', component: HomeComponent, pathMatch: 'full'}
];