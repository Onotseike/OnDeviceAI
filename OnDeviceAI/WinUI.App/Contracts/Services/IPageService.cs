﻿namespace WinUI.App.Contracts.Services;

public interface IPageService
{
    Type GetPageType(string key);
}
