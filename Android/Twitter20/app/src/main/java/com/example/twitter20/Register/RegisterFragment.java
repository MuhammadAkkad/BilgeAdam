package com.example.twitter20.Register;

import android.content.Intent;
import android.database.sqlite.SQLiteDatabase;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;

import com.example.twitter20.DB.DbContract;
import com.example.twitter20.DB.DbHelper;
import com.example.twitter20.R;
import com.example.twitter20.Login.LoginActivity;


public class RegisterFragment extends AppCompatActivity {
    DbHelper dbHelper;
    SQLiteDatabase dbWrite;
    SQLiteDatabase dbRead;
    Button btnAddUser;
    RegisterPresenter mRegisterPresenter = new RegisterPresenter(this);


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_register_fragment);
        dbHelper = new DbHelper(this);
        dbWrite = dbHelper.getWritableDatabase();
        dbRead = dbHelper.getReadableDatabase();
        btnAddUser = findViewById(R.id.Sign_up);
        btnAddUser.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                RegisterNewUser(v);
            }
        });
    }


    public void RegisterNewUser(View view) {
        TextView name = findViewById(R.id.name);
        TextView nickName = findViewById(R.id.nickname);
        TextView account = findViewById(R.id.account);
        TextView password = findViewById(R.id.password);

        String mName, mNickName, mAccount, mPassword;
        mName = name.getText().toString();
        mNickName = nickName.getText().toString();
        mAccount = account.getText().toString();
        mPassword = password.getText().toString();

        if (mName.length() <= 0 || mNickName.length() <= 0 || mAccount.length() <= 0 || mPassword.length() <= 0) {
            Toast.makeText(this, "All fields must be entered", Toast.LENGTH_SHORT).show();
            Intent i = new Intent(getApplicationContext(), RegisterFragment.class);
            startActivity(i);
        } else {

            if (mRegisterPresenter.isUserExists(DbContract.UserEntry.TABLE_NAME, DbContract.UserEntry.COLUMN_ACCOUNT, mAccount)) {
                mRegisterPresenter.InsertValues(mName, mNickName, mAccount, mPassword);
                Toast.makeText(this, "User added", Toast.LENGTH_SHORT).show();
                Intent i = new Intent(getApplicationContext(), LoginActivity.class);
                startActivity(i);
            } else
                Toast.makeText(this, "User already exists", Toast.LENGTH_LONG).show();
        }
    }

}