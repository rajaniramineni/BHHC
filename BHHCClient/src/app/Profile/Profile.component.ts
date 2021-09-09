import { identifierModuleUrl } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';

import { Apollo, QueryRef } from 'apollo-angular';
import gql from 'graphql-tag'
const ReasonsQuery = gql`
 query reasons {
  reasons{
    id
    description    
  }
}`;
const StrengthsQuery = gql`
 query strengths {
  strengths{
    id
    strengthDescription    
  }
}`;
const goodFitsQuery = gql`
 query goodFitFacts {
  goodFitFacts{
    id
    factdescription    
  }
}`;

@Component({
  selector: 'Profile',
  templateUrl: './Profile.component.html',
  styleUrls: ['./Profile.component.css']
})
export class ProfileComponent implements OnInit {

  reasons: any[]= [];
  strengths: any[]= [];
  gfFacts: any[]= [];
  private query: QueryRef<any>;
    constructor(private apollo: Apollo) { }
  
    ngOnInit(): void {
       this.apollo.watchQuery({query : ReasonsQuery}).valueChanges.subscribe((result:any) => {
        this.reasons = result?.data?.reasons;        
      });
      this.apollo.watchQuery({query : StrengthsQuery}).valueChanges.subscribe((result:any) => {
        this.strengths = result?.data?.strengths;        
      });
      this.apollo.watchQuery({query : goodFitsQuery}).valueChanges.subscribe((result:any) => {
        this.gfFacts = result?.data?.goodFitFacts;        
      });
    }
    public cardClick(event: any){
      let el: any =document.getElementsByClassName('cards');
      let siblings =el[0].children ;
  for(let sib of siblings) {
    if(sib.id !== event.currentTarget.parentElement.id){
      if(sib.classList.contains('active')){
        sib.children[0].classList.remove('active');
      }
      sib.classList.remove('active');
    }
    else{
      sib.classList.add('active');
      event.currentTarget.classList.add('active');
    }
  }  
     

}
   

}

