/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { FootsComponent } from './foots.component';

describe('FootsComponent', () => {
  let component: FootsComponent;
  let fixture: ComponentFixture<FootsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FootsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FootsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
