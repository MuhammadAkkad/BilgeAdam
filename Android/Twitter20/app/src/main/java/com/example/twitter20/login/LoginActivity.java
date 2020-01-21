package com.example.twitter20.login;

import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

import androidx.appcompat.app.AppCompatActivity;

import com.example.twitter20.MainActivity;
import com.example.twitter20.R;
import com.example.twitter20.Register.RegisterFragment;

public class LoginActivity extends AppCompatActivity {

    LoginPresenter login = new LoginPresenter(this, null);
    Button signUp;


    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);

        final SharedPreferences pref = getSharedPreferences("com.example.twitter20", Context.MODE_PRIVATE);
        final EditText usernameEditText = findViewById(R.id.username);
        final EditText passwordEditText = findViewById(R.id.password);
        final Button loginButton = findViewById(R.id.login);

        //final ProgressBar loadingProgressBar = findViewById(R.id.loading);
        signUp = findViewById(R.id.btn_sign_up);
        signUp.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent i = new Intent(getApplicationContext(), RegisterFragment.class);
                startActivity(i);
            }
        });

        loginButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                boolean IsAuthorized = login.LogIn(usernameEditText.getText().toString(), passwordEditText.getText().toString(),
                        pref);

                if (IsAuthorized) {
                    Intent i = new Intent(getApplicationContext(), MainActivity.class);
                    startActivity(i);
                } else {
                    Intent i = new Intent(getApplicationContext(), LoginActivity.class);
                    startActivity(i);
                }
            }
        });
    }


}
