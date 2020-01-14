package com.example.twitter20.ui.login;

import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

import androidx.appcompat.app.AppCompatActivity;

import com.example.twitter20.DbContract;
import com.example.twitter20.DbHelper;
import com.example.twitter20.MainActivity;
import com.example.twitter20.R;
import com.example.twitter20.ui.Register.RegisterFragment;

public class LoginActivity extends AppCompatActivity {


    Button signUp;


    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);


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
                //loadingProgressBar.setVisibility(View.VISIBLE);
                boolean IsAuthorized = login(usernameEditText.getText().toString(), passwordEditText.getText().toString());

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

    public boolean login(String username, String password) {
        //try {
        DbHelper dbHelper = new DbHelper(this);
        SQLiteDatabase dbWrite;
        SQLiteDatabase dbRead = dbHelper.getReadableDatabase();

        // TODO: handle loggedInUser authentication
        Cursor cursor = dbRead.rawQuery("SELECT * FROM user WHERE  account = " + "\'" + username + "\'" + " AND password = " + "\'" + password + "\'",
                null);

        final SharedPreferences pref = getSharedPreferences("com.example.twitter20", Context.MODE_PRIVATE);
        int ID;
        String Name;
        String NickName;

        try {
            if (cursor.getCount() > 0) {
                while (cursor.moveToNext()) {
                    ID = cursor.getInt(cursor.getColumnIndexOrThrow("_id"));
                    Name = cursor.getString(cursor.getColumnIndexOrThrow(DbContract.UserEntry.COLUMN_NAME));
                    NickName = cursor.getString(cursor.getColumnIndexOrThrow(DbContract.UserEntry.COLUMN_NICKNAME));
                    pref.edit().putInt("ID", ID).apply();
                    pref.edit().putString("Name", Name).apply();
                    pref.edit().putString("NickName", NickName).apply();
                }
                cursor.close();
                return true;
            } else return false;
        } catch (Exception e) {
            return false;
        }
    }
}
