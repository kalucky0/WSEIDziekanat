using System;

namespace WSEIDziekanat.Contracts.Services;

public interface IPageService
{
    Type GetPageType(string key);
}
