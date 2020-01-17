package com.example.mvp.main;

public class MainPresenter {
    private MainView mListener;


    MainPresenter(MainView mainListener) {
        this.mListener = mainListener;
    }


    public void detirmainGender(String str) {
        if (str.equals("Ahmed")) {
            mListener.ShowMessage("Male");
        } else if (str.equals("Ayse")) {
            mListener.ShowMessage("Female");
        } else {
            mListener.ShowMessage("Alain");
        }
    }




}
