package com.example.fuel.repository

import com.example.fuel.api.RetrofitInstance
import com.example.fuel.model.account.UserRegistration
import retrofit2.Response

class UserRepository {

    suspend fun postLogin(user: UserRegistration): Response<UserRegistration> {
        return RetrofitInstance.accountApi.postLogin(user.username, user.password)
    }

    suspend fun postRegister(user: UserRegistration?): Response<UserRegistration> {
        return RetrofitInstance.accountApi.postRegister(user!!)
    }
}