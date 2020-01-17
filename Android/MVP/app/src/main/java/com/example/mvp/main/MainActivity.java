package com.example.mvp.main;

import android.os.Bundle;
import android.view.View;
import android.widget.EditText;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;

import com.example.mvp.R;

public class MainActivity extends AppCompatActivity implements MainView {
    EditText mEditText;

    MainPresenter mMainPresenter;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        mMainPresenter = new MainPresenter(this);
        mEditText = findViewById(R.id.editText);

    }
    public void ClickedButton(View view) {
        mMainPresenter.detirmainGender(mEditText.getText().toString());
    }

    @Override
    public void ShowMessage(String str) {
        Toast.makeText(this, str, Toast.LENGTH_LONG).show();
    }

}
